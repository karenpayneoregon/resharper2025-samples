using System.Text;
using System.Text.RegularExpressions;

namespace ToGeneratedRegexSample.Classes1;
public static class TextCleaner
{
    private static readonly Regex MojibakeHint = new(@"[ÃÂ¢â€œ”€™¡¼©®†•™·°±·¼½¾œšž]", RegexOptions.Compiled);
    private static readonly Regex OddSpaces = new(@"[\u00A0\u1680\u180E\u2000-\u200B\u202F\u205F\u2060\u3000]", RegexOptions.Compiled);
    private static readonly Regex Controls = new(@"[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]", RegexOptions.Compiled);
    private static readonly Regex CollapseWs = new(@"[ \t\u00A0\u2000-\u200B\u202F\u205F\u2060]+", RegexOptions.Compiled);

    /// <summary>
    /// Cleans a string by fixing common encoding issues, normalizing whitespace,
    /// and optionally folding ordinals/superscripts to ASCII.
    /// </summary>
    /// <param name="foldOrdinalsToAscii">If true, 5ª -> 5a and 1º -> 1o.</param>
    public static string Clean(string input, bool foldOrdinalsToAscii = true)
    {
        if (string.IsNullOrEmpty(input)) return input;

        // 1) Aggressive encoding repair with stabilization
        string prev, cur = input;
        for (int i = 0; i < 3; i++)
        {
            prev = cur;
            cur = FixEncodingHeuristic(cur);
            if (cur == prev) break;
        }

        // 2) Unicode normalization
        cur = cur.Normalize(NormalizationForm.FormC);

        // 3) Normalize spaces and strip control chars
        cur = OddSpaces.Replace(cur, " ");
        cur = Controls.Replace(cur, string.Empty);
        cur = cur.Replace("\r\n", "\n").Replace("\r", "\n");
        cur = string.Join("\n",
            cur.Split('\n').Select(line => CollapseWs.Replace(line, " ").Trim())
        );

        // 4) Ordinals/superscripts handling
        cur = foldOrdinalsToAscii ? FoldOrdinalsToAscii(cur) : cur;

        return cur.Trim();
    }

    private static string FixEncodingHeuristic(string text)
    {
        if (!MojibakeHint.IsMatch(text)) return text;

        string best = text;
        int bestScore = Score(best);

        TryCandidate(ref best, ref bestScore, Reinterpret(text, "windows-1252", Encoding.UTF8));
        TryCandidate(ref best, ref bestScore, Reinterpret(text, "ISO-8859-1", Encoding.UTF8));

        var once1252 = Reinterpret(text, "windows-1252", Encoding.UTF8);
        TryCandidate(ref best, ref bestScore, Reinterpret(once1252, "windows-1252", Encoding.UTF8));

        var onceLatin1 = Reinterpret(text, "ISO-8859-1", Encoding.UTF8);
        TryCandidate(ref best, ref bestScore, Reinterpret(onceLatin1, "ISO-8859-1", Encoding.UTF8));

        return best;
    }

    private static void TryCandidate(ref string best, ref int bestScore, string candidate)
    {
        int s = Score(candidate);
        if (s > bestScore) { best = candidate; bestScore = s; }
    }

    private static int Score(string s)
    {
        if (string.IsNullOrEmpty(s)) return int.MinValue;
        int goodLetters = s.Count(char.IsLetter);
        int bad = s.Count(c => c == '�' || c == '\uFFFD') +
                  Regex.Matches(s, @"[ÃÂ¢â€œ”€™]").Count;
        return goodLetters - 5 * bad;
    }

    private static string Reinterpret(string input, string fromEncodingName, Encoding to)
    {
        var from = Encoding.GetEncoding(fromEncodingName);
        byte[] bytes = from.GetBytes(input);
        return to.GetString(bytes);
    }

    /// <summary>
    /// Folds feminine/masculine ordinals and numeric superscripts to ASCII.
    ///  - U+00AA 'ª' -> 'a'
    ///  - U+00BA 'º' -> 'o'
    ///  - ¹²³⁰…⁹ -> 1..9,0
    /// </summary>
    private static string FoldOrdinalsToAscii(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;

        var sb = new StringBuilder(s.Length);
        foreach (var ch in s)
        {
            sb.Append(ch switch
            {
                '\u00AA' => 'a', // ª
                '\u00BA' => 'o', // º
                '\u00B9' => '1', // ¹
                '\u00B2' => '2', // ²
                '\u00B3' => '3', // ³
                '\u2070' => '0', // ⁰
                '\u2074' => '4', // ⁴
                '\u2075' => '5', // ⁵
                '\u2076' => '6', // ⁶
                '\u2077' => '7', // ⁷
                '\u2078' => '8', // ⁸
                '\u2079' => '9', // ⁹
                _ => ch
            });
        }
        return sb.ToString();
    }
}

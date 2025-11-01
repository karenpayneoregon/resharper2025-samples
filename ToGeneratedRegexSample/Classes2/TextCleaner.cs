using System.Text;
using System.Text.RegularExpressions;

namespace ToGeneratedRegexSample.Classes2;

public static partial class TextCleaner
{
    private static readonly Regex MojibakeHint = MojibakeIndicatorsRegex();
    private static readonly Regex OddSpaces = OddSpacesRegex();
    private static readonly Regex Controls = ControlsRegex();
    private static readonly Regex CollapseWs = CollapseWhitespaceRegex();

    /// <summary>
    /// Cleans the specified input string by addressing common encoding issues, 
    /// normalizing whitespace, and optionally converting ordinals or superscripts to ASCII.
    /// </summary>
    /// <param name="input">The input string to be cleaned.</param>
    /// <param name="foldOrdinalsToAscii">
    /// A boolean value indicating whether to convert ordinals and superscripts 
    /// (e.g., '5ª' to '5a' and '1º' to '1o') to their ASCII equivalents. 
    /// Defaults to <c>true</c>.
    /// </param>
    /// <returns>
    /// A cleaned and normalized string with encoding issues fixed, 
    /// unnecessary whitespace removed, and optionally ordinals/superscripts folded to ASCII.
    /// </returns>
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
        cur = string.Join("\n", cur.Split('\n').Select(line => CollapseWs.Replace(line, " ").Trim())
        );

        // 4) Ordinals/superscripts handling
        cur = foldOrdinalsToAscii ? FoldOrdinalsToAscii(cur) : cur;

        return cur.Trim();
    }

    /// <summary>
    /// Attempts to fix encoding issues in the provided text by applying heuristic-based transformations.
    /// </summary>
    /// <param name="text">The input text potentially containing encoding issues.</param>
    /// <returns>
    /// A string with encoding issues mitigated or resolved based on heuristic analysis.
    /// </returns>
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

    /// <summary>
    /// Evaluates a candidate string against the current best string and updates the best string
    /// and its score if the candidate has a higher score.
    /// </summary>
    /// <param name="best">
    /// A reference to the current best string. This will be updated if the candidate string
    /// has a higher score.
    /// </param>
    /// <param name="bestScore">
    /// A reference to the score of the current best string. This will be updated if the candidate
    /// string has a higher score.
    /// </param>
    /// <param name="candidate">
    /// The candidate string to be evaluated against the current best string.
    /// </param>
    private static void TryCandidate(ref string best, ref int bestScore, string candidate)
    {
        int score = Score(candidate);
        if (score > bestScore) { best = candidate; bestScore = score; }
    }

    /// <summary>
    /// Evaluates the quality of the given string by scoring it based on the number of valid letters 
    /// and penalizing it for the presence of invalid or problematic characters.
    /// </summary>
    /// <param name="sender">The string to be evaluated and scored.</param>
    /// <returns>
    /// An integer score representing the quality of the string. A higher score indicates better quality, 
    /// while a lower score indicates more issues such as invalid characters or encoding problems.
    /// </returns>
    private static int Score(string sender)
    {
        if (string.IsNullOrEmpty(sender)) return int.MinValue;
        int goodLetters = sender.Count(char.IsLetter);
        int bad = sender.Count(c => c is '�' or '\uFFFD') + MojibakeCommonIndicatorsRegex().Matches(sender).Count;
        return goodLetters - 5 * bad;
    }

    /// <summary>
    /// Reinterprets the input string by converting it from one encoding to another.
    /// </summary>
    /// <param name="input">The input string to be reinterpreted.</param>
    /// <param name="fromEncodingName">
    /// The name of the source encoding from which the input string will be converted.
    /// </param>
    /// <param name="to">
    /// The target <see cref="Encoding"/> to which the input string will be converted.
    /// </param>
    /// <returns>
    /// A string reinterpreted from the source encoding to the target encoding.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the specified encoding name is invalid or not supported.
    /// </exception>
    /// <exception cref="DecoderFallbackException">
    /// Thrown if a decoding error occurs during the conversion process.
    /// </exception>
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
    private static string FoldOrdinalsToAscii(string item)
    {
        if (string.IsNullOrEmpty(item)) return item;

        var sb = new StringBuilder(item.Length);
        foreach (var ch in item)
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

    [GeneratedRegex(@"[ \t\u00A0\u2000-\u200B\u202F\u205F\u2060]+", RegexOptions.Compiled)]
    private static partial Regex CollapseWhitespaceRegex();
    [GeneratedRegex(@"[\x00-\x08\x0B\x0C\x0E-\x1F\x7F]", RegexOptions.Compiled)]
    private static partial Regex ControlsRegex();
    [GeneratedRegex(@"[\u00A0\u1680\u180E\u2000-\u200B\u202F\u205F\u2060\u3000]", RegexOptions.Compiled)]
    private static partial Regex OddSpacesRegex();
    [GeneratedRegex(@"[ÃÂ¢â€œ”€™¡¼©®†•™·°±·¼½¾œšž]", RegexOptions.Compiled)]
    private static partial Regex MojibakeIndicatorsRegex();
    [GeneratedRegex(@"[ÃÂ¢â€œ”€™]")]
    private static partial Regex MojibakeCommonIndicatorsRegex();
}
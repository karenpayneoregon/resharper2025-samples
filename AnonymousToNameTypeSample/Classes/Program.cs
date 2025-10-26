using System.Reflection;
using System.Runtime.CompilerServices;
using AnonymousToNameTypeSample.Classes.Configuration;
using ConsoleHelperLibrary.Classes;

// ReSharper disable once CheckNamespace
namespace AnonymousToNameTypeSample
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            var assembly = Assembly.GetEntryAssembly();
            var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

            Console.Title = product!;

            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

            SetupLogging.Development();
   

        }

    }
}

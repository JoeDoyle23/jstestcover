using System;
using System.Reflection;

namespace jstestcover
{
    class Program
    {
        static void Main(string[] args)
        {
            EnableEmbeddedAssemblyLoading();

            var settings = new Settings();

            if (!CommandLine.Parser.Default.ParseArguments(args, settings) || string.IsNullOrEmpty(settings.InputTarget))
            {
                Console.WriteLine(settings.GetUsage()); 
                return;
            }

            var coverController = new CoverController(settings);
            coverController.RunInstrumentation();
        }

        private static void EnableEmbeddedAssemblyLoading()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, arguments) =>
                {
                    var resourceName = "ncoverjs.lib." + new AssemblyName(arguments.Name).Name + ".dll";
                    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        var assemblyData = new Byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return Assembly.Load(assemblyData);
                    }
                };
        }
    }
}

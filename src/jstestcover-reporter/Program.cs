using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace jstestcoverreporter
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

        }

        private static void EnableEmbeddedAssemblyLoading()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, arguments) =>
            {
                var resourceName = "jstestcoverreporter.lib." + new AssemblyName(arguments.Name).Name + ".dll";
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

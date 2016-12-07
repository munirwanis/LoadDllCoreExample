using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;
using hue;
// using plugins;

namespace loader
{
    public class Program
    {

        public const string PluginPath=@"C:\Users\mriboli\Documents\GitHub\experimental\LoadDllCoreExample\plugins\bin\Debug\netcoreapp1.1\plugins.dll";

        public static void Main(string[] args)
        {

            // AssemblyLoadContext.Default.Resolving += (context, name) =>
            // {
            //     // avoid loading *.resources dlls, because of: https://github.com/dotnet/coreclr/issues/8416
            //     if (name.Name.EndsWith("resources"))
            //     {
            //         return null;
            //     }

            //     var dependencies = DependencyContext.Default.RuntimeLibraries;
            //     foreach (var library in dependencies)
            //     {
            //         if (IsCandidateLibrary(library, name))
            //         {
            //             return context.LoadFromAssemblyName(new AssemblyName(library.Name));
            //         }
            //     }

            //     var foundDlls = Directory.GetFileSystemEntries(new FileInfo(@"C:\Users\mriboli\Documents\GitHub\experimental\LoadDllCoreExample\plugins\bin\Debug\netcoreapp1.1").FullName, name.Name + ".dll", SearchOption.AllDirectories);
            //     if (foundDlls.Any())
            //     {
            //         return context.LoadFromAssemblyPath(foundDlls[0]);
            //     }

            //     return context.LoadFromAssemblyName(name);
            // };



            var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(PluginPath);
            // Assembly myAssembly = Assembly.Load(AssemblyLoadContext.GetAssemblyName(PluginPath));
            var myType = myAssembly.GetType("plugins.Plugin");
            // var myInstance =(IDoSomething)Activator.CreateInstance(myType);
            object myInstance =Activator.CreateInstance(myType);

            System.Console.WriteLine(((IDoSomething)myInstance).DoIt());
            System.Console.WriteLine(((IPlugin)myInstance).HelloWorld("FDP"));
        }

        // private static bool IsCandidateLibrary(RuntimeLibrary library, AssemblyName assemblyName)
        // {
        //     return (library.Name == (assemblyName.Name))
        //             || (library.Dependencies.Any(d => d.Name.StartsWith(assemblyName.Name)));
        // }
    }
}

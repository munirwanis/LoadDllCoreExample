using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using plugins;

namespace loader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var asl = new AssemblyLoader();
            var asm = asl.LoadFromAssemblyPath("/home/munirwanis/Documents/Git/LoadDllCore/plugins/bin/Debug/netcoreapp1.1/plugins.dll");

            var type = asm.GetType("plugins.Plugin");
            dynamic obj = Activator.CreateInstance(type);
            // Console.WriteLine(obj.SayHello("John Doe"));
            string response = obj.HelloWorld("Hue br");
            Console.WriteLine(response);
        }
    }
}

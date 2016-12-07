using System;
using hue;

namespace plugins
{
    public class Plugin : IDoSomething, IPlugin
    {
        public string HelloWorld(string something) {
            return $"Hello, {something}";
        }

        public string DoIt(){
            return "Vai se fuder!";
        }
    }
}

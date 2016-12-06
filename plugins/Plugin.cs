using System;

namespace plugins
{
    public class Plugin : IPlugin
    {
        public string Name { get; set; }

        public string HelloWord(string something) {
            return $"Hello, {something}";
        }
    }
}

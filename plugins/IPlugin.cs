namespace plugins
{
    public interface IPlugin
    {
         string Name { get; set; }

         string HelloWord(string something);
    }
}
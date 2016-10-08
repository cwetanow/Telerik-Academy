using SchoolSystem.UI.Models;

namespace SchoolSystem.UI
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var commandParser = new CommandParser();

            Engine.Start(reader, writer, commandParser);
        }
    }
}
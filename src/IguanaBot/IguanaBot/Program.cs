
namespace IguanaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var iguanaBot = new Bot();
            iguanaBot.RunBotAsync().GetAwaiter().GetResult();

        }
    }
}

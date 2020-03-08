namespace IguanaBot.Controller
{
    class Runner
    {
        static void Main(string[] args)
        {
            var iguanaBot = new IguanaBot();
            iguanaBot.InitializeBot().GetAwaiter().GetResult();
        }
    }
}

namespace IguanaBot.Controller.Entry
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

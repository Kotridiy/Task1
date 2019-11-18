using SweetTask.DemoBuilders;
using SweetTask.ConsoleManager;

namespace SweetTask
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoSweetBuilder sweetBuilder = new DemoSweetBuilder();
            DemoSweetBoxBulder boxBuilder = new DemoSweetBoxBulder(sweetBuilder);

            ConsoleSweetBoxManager manager = new ConsoleSweetBoxManager(sweetBuilder, boxBuilder);
            manager.Begin();
        }
    }
}

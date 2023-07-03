using DbContext;
using RpcServer;

namespace consoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dnContext = new CosmosContext();
            var test = new RpcServer.RpcServer(dnContext);
            Console.ReadKey();
        }
    }
}
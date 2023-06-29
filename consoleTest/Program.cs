using RpcServer;

namespace consoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = new RpcServer.RpcServer();
            Console.ReadKey();
        }
    }
}
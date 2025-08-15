using System;
using GraphNetwork.Models;

namespace GraphNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Network network = new(5);
            network.Connect(0, 1);
            network.Connect(1, 2);
            network.Connect(2, 3);
            network.Connect(3, 4);

            Console.WriteLine($"Is 0 connected to 1? {network.Query(0, 1)}");
            Console.WriteLine($"Connection level between 0 and 1: {network.LevelConnection(0, 1)}");

            Console.WriteLine($"Is 0 connected to 4? {network.Query(0, 4)}");
            Console.WriteLine($"Connection level between 0 and 4: {network.LevelConnection(0, 4)}");

            network.Disconnect(1, 2);
            Console.WriteLine($"Is 0 connected to 4 after disconnecting 1? {network.Query(0, 4)}");

            network.Connect(0, 2);
            Console.WriteLine($"Is 0 connected to 4 after connecting 0 to 2? {network.Query(0, 4)}");
        }
    }
}
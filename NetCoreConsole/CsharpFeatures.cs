using System;
using System.Threading.Tasks;
//using static Console.WriteLine =;

namespace Hello
{
    class Program
    {
        static async Task Main(string[] args)
        {

            (var name, var userId) = IReturnsATuple();
            await Task.Delay(1);
            Console.WriteLine($"{name} has a user id:{userId}");

        }

        //tuples
        private static (string a, string b) IReturnsATuple()
        {
            return ("name", "userId");
        }

        // private static void WriteInfinitLog()
        // {
        //     var lines = $"Millisecond is:{DateTime.Now.Millisecond}{Environment.NewLine}";
        //     Task.Delay(1000).ContinueWith(t =>
        //     {
        //         System.IO.Directory.CreateDirectory("dataVol");
        //         System.IO.File.AppendAllText(@"./dataVol/WriteLines.txt", lines);
        //         WriteInfinitLog();

        //     }
        //     );
        // }
    }
}
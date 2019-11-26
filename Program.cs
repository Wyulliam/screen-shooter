using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenShooter
{
    class Program
    {
        private static string _path = "C:\\temp";
        private static int _timespan = 3000;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Path:");
            _path = Console.ReadLine();

            Console.WriteLine("Timespan in MS:");
            _timespan = Int32.Parse(Console.ReadLine());

            DirectoryInfo dir = new DirectoryInfo(_path);

            if (!dir.Exists) dir.Create();

            while (true)
            {
                await StartPrinting();
                Thread.Sleep(_timespan);
            }

        }

        private async static Task StartPrinting()
        {
            var name = DateTime.Now.ToString("MMddmmss");
            PrintScreen ps = new PrintScreen();
            ps.CaptureScreenToFile($"{_path}\\{name}.png", ImageFormat.Png);
            Console.WriteLine($"Printed {name}");
        }
    }
}
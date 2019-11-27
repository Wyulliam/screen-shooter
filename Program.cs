using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenShooter
{
    class Program
    {
        private static string _path = "C:\\temp\\not posted";
        private static int _timespan = 3000;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Path:");
            var path = Console.ReadLine();
            if (path != string.Empty)
                _path = path;

            Console.WriteLine("Timespan in MS:");
            _timespan = Int32.Parse(Console.ReadLine());

            DirectoryInfo dir = new DirectoryInfo(_path);
            PrintScreen ps = new PrintScreen();

            if (!dir.Exists) dir.Create();

            var countScreens = 0;

            while (true)
            {
                await StartPrinting(ps);
                Thread.Sleep(_timespan);

                if (countScreens == 20)
                {
                    System.GC.Collect();
                    countScreens = 0;
                }
                countScreens++;
            }

        }

        private async static Task StartPrinting(PrintScreen ps)
        {
            var name = DateTime.Now.ToString("yyyyMMddhhmmss");
            ps.CaptureScreenToFile($"{_path}\\{name}.png", ImageFormat.Png);
            Console.WriteLine($"Printed {name}");
        }
    }
}
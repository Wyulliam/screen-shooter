using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ScreenShooter
{
    class Program
    {
        private static DirectoryInfo dir = new DirectoryInfo("C:\\temp");
        static async Task Main(string[] args)
        {
            if (!dir.Exists) dir.Create();

            while (true)
            {
                await StartPrinting();
                Thread.Sleep(3000);
            }

        }

        private async static Task StartPrinting()
        {
            var name = DateTime.Now.ToString("MMddmmss");
            PrintScreen ps = new PrintScreen();
            ps.CaptureScreenToFile($"{dir}\\{name}.png", ImageFormat.Png);
        }
    }
}
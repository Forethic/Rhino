using Rhino.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rhino.TimedShutdown
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 设置开机自启
            RegistryTableUtil.SetAutoRun();

            // 比较时间 0 ~ 7
            var currentDateTime = DateTime.Now;
            if (currentDateTime.Hour >= 0 && currentDateTime.Hour <= 7)
            {
                SystemUtil.PowerOff();
            }
            else
            {
                var tomorrow = currentDateTime.AddDays(1);
                // 设定定时器
                var shutdownDateTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 0, 0, 0);
                Task.Delay(shutdownDateTime - currentDateTime).ContinueWith((t) => { SystemUtil.PowerOff(); });
                while (true) { Thread.Sleep(24 * 60 * 60 * 1000); }
            }
        }
    }
}
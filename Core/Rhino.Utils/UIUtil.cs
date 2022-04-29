using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Rhino.Utils
{
    public static class UIUtil
    {
        public static void Invoke(Action callback) => Application.Current.Dispatcher.Invoke(callback);

        public static void BeginInvoke(Delegate method, params object[] args) => Application.Current.Dispatcher.BeginInvoke(method, args);

        /// <summary>
        /// 定时任务 去检测 Ui线程是否卡顿
        /// </summary>
        /// <param name="dispatcher">Ui线程, 可从窗口或者Application.Current.Dispatcher 获取</param>
        public static void TimedCheckDispatcherHang(Dispatcher dispatcher, int interval = 2000)
        {
            var timer = new System.Timers.Timer();
            timer.Elapsed += async (s, e) =>
            {
                var isHang = await CheckDispatcherHangAsync(dispatcher, interval);
                LogUtil.Log.Debug("Ui线程是否卡顿： " + isHang);
            };
            timer.Interval = interval + 50;
            timer.AutoReset = true;
            timer.Start();
        }

        /// <summary>
        /// 检测 UI线程是否卡顿
        /// </summary>
        /// <param name="dispatcher">Ui线程, 可从窗口或者Application.Current.Dispatcher 获取</param>
        /// <returns>true：卡顿</returns>
        public static async Task<bool> CheckDispatcherHangAsync(Dispatcher dispatcher, int delay = 2000)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            _ = dispatcher.InvokeAsync(() => taskCompletionSource.TrySetResult(true));
            await Task.WhenAny(taskCompletionSource.Task, Task.Delay(delay));
            // 如果任务还没完成，就是界面卡了
            return taskCompletionSource.Task.IsCompleted is false;
        }
    }
}
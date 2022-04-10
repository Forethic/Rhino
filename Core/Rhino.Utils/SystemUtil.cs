using System;

namespace Rhino.Utils
{
    public static class SystemUtil
    {
        /// <summary>
        /// 重启
        /// </summary>
        public static void Reboot() => DoExitWin(NativeConstants.EWX_FORCE | NativeConstants.EWX_REBOOT);

        /// <summary>
        /// 关机
        /// </summary>
        public static void PowerOff() => DoExitWin(NativeConstants.EWX_FORCE | NativeConstants.EWX_POWEROFF);

        /// <summary>
        /// 注销
        /// </summary>
        public static void LogoOff() => DoExitWin(NativeConstants.EWX_FORCE | NativeConstants.EWX_LOGOFF);

        private static void DoExitWin(int flg)
        {
            TokPriv1Luid tp;
            IntPtr hproc = NativeMethod.GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            NativeMethod.OpenProcessToken(hproc, NativeConstants.TOKEN_ADJUST_PRIVILEGES | NativeConstants.TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = NativeConstants.SE_PRIVILEGE_ENABLED;
            NativeMethod.LookupPrivilegeValue(null, NativeConstants.SE_SHUTDOWN_NAME, ref tp.Luid);
            NativeMethod.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            NativeMethod.ExitWindowsEx(flg, 0);
        }
    }
}
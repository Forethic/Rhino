namespace Rhino.Utils
{
    /// <summary>
    /// WinApi - 定义的常量
    /// </summary>
    public class NativeConstants
    {
        public const int SE_PRIVILEGE_ENABLED = 0x00000002;

        public const int TOKEN_QUERY = 0x00000008;
        public const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;

        public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

        public const int EWX_LOGOFF      = 0x00000000;
        public const int EWX_SHUTDOWN    = 0x00000001;
        public const int EWX_REBOOT      = 0x00000002;
        public const int EWX_FORCE       = 0x00000004;
        public const int EWX_POWEROFF    = 0x00000008;
        public const int EWX_FORCEIFHUNG = 0x00000010;
    }
}
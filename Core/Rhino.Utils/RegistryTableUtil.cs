using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;

namespace Rhino.Utils
{
    public enum RegistryRoot
    {
        HKEY_CLASSES_ROOT,
        HKEY_CURRENT_USER,
        HKEY_LOCAL_MACHINE,
        HKEY_USERS,
        HKEY_CURRENT_CONFIG,
    }

    /// <summary>
    /// 注册表工具类
    /// </summary>
    public static class RegistryTableUtil
    {
        /// <summary>
        /// Window中程序开机自启路径 
        /// </summary>
        public static readonly string PRODUCT_AUTORUN_KEY = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// 设置开机自启
        /// </summary>
        /// <param name="exePath"></param>
        public static void SetAutoRun(string exePath = "")
        {
            if (string.IsNullOrEmpty(exePath) || !File.Exists(exePath))
            {
                var assembly = Assembly.GetEntryAssembly();
                exePath = assembly.Location;
            }
            string key = "auto_" + Path.GetFileNameWithoutExtension(exePath);

            SetValue(RegistryRoot.HKEY_CURRENT_USER, PRODUCT_AUTORUN_KEY, key, string.Format("\"{0}\"", exePath));
        }

        public static void SetValue(RegistryRoot root, string path, string key, string value, RegistryValueKind kind = RegistryValueKind.String)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            RegistryKey rootKey = root.RigisterRootToRegistryKey();
            RegistryKey registryKey = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
            registryKey.SetValue(key, value, kind);
        }

        private static RegistryKey RigisterRootToRegistryKey(this RegistryRoot root)
        {
            switch (root)
            {
                case RegistryRoot.HKEY_CLASSES_ROOT:
                    return Registry.ClassesRoot;
                case RegistryRoot.HKEY_CURRENT_CONFIG:
                    return Registry.CurrentConfig;
                case RegistryRoot.HKEY_LOCAL_MACHINE:
                    return Registry.LocalMachine;
                case RegistryRoot.HKEY_USERS:
                    return Registry.Users;
                case RegistryRoot.HKEY_CURRENT_USER:
                default:
                    return Registry.CurrentUser;
            }
        }
    }
}
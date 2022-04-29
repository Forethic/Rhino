using System;

namespace Rhino.Utils
{
    public interface ILog
    {
        void Error(Exception ex);

        void Error(string msg);

        void Info(string msg);

        void Debug(string msg);
    }

    public class LogUtil
    {
        private class NullLogger : ILog
        {
            public void Debug(string msg)
            {
            }

            public void Error(Exception ex)
            {
            }

            public void Error(string msg)
            {
            }

            public void Info(string msg)
            {
            }
        }

        public static ILog Log { get; set; } = new NullLogger();
    }
}
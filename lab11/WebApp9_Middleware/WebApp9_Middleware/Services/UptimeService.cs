using System.Diagnostics;

namespace WebApp9_Middleware.Services
{
    public class UptimeService
    {
        private Stopwatch timer;

        public UptimeService()
        {
            timer = Stopwatch.StartNew();
        }

        public long Uptime => timer.ElapsedMilliseconds;
    }
}

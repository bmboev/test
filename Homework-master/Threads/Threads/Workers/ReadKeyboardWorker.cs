using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads.Workers
{
    public class ReadKeyboardWorker : IWorker
    {
        private TimeSpan _interval;

        public ReadKeyboardWorker(TimeSpan interval)
        {
            _interval = interval;
        }
        public void Execute(CancellationToken token = default)
        {
            DateTime now = DateTime.UtcNow;
            while (!token.IsCancellationRequested)
            {
                now = DateTime.UtcNow;

                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    break;
                }
                
                if (!Wait(now, token))
                {
                    break;
                }
            }
        }

        public bool Wait(DateTime taskStartedAt, CancellationToken token = default)
        {
            return true;
        }
    }

}

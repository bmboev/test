using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads.Workers
{
    public class GrayWorker : IWorker
    {
        private TimeSpan _interval;

        public GrayWorker(TimeSpan interval)
        {
            _interval = interval;
        }

        public void Execute(CancellationToken token = default)
        {
            DateTime now = DateTime.UtcNow;
            while (!token.IsCancellationRequested)
            {
                now = DateTime.UtcNow;

                Console.WriteLine("gray color");

                if (!Wait(now, token))
                {
                    break;
                }
            }
        }

        public bool Wait(DateTime taskStartedAt, CancellationToken token = default)
        {
            try
            {
                // Substract from interval time for execution of the task
                var waitTime = _interval - (DateTime.UtcNow - taskStartedAt);

                // if task consumes more time than defined _interval then wait full _interval
                return !token.WaitHandle.WaitOne(waitTime < TimeSpan.Zero ? _interval : waitTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while waiting {ex.Message} {this.GetType().Name}");
                return false;
            }
        }
    }
}

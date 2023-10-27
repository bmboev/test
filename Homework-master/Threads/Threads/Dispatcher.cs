using System;
using System.Collections.Generic;
using System.Threading;
using Threads.Workers;

namespace Threads
{
    internal class Dispatcher
    {
        private CancellationTokenSource _cancellationTokenSource;
        private List<Thread> _threadList;

        public Dispatcher(CancellationTokenSource cancellationTokenSource)
        {
            _cancellationTokenSource = cancellationTokenSource;
            _threadList = new List<Thread>();
        }

        public IWorker AddWorker(IWorker worker, CancellationToken token = default)
        {
            if (worker is null)
            {
                throw new ArgumentNullException(nameof(worker));
            }

            var thread = new Thread(() =>
                {
                    worker.Execute(_cancellationTokenSource.Token);
                    _cancellationTokenSource.Cancel();
                });

            _threadList.Add(thread);
            return worker;
        }



        public void StartWorkers()
        {
            _threadList.ForEach(f => f.Start());
        }

        public void WaitWorkers()
        {
            _threadList.ForEach(f =>f.Join());
        }
    }
}


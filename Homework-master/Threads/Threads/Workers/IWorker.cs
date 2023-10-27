using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads.Workers
{
    public interface IWorker
    {
        public void Execute(CancellationToken token = default(CancellationToken));
        public bool Wait(DateTime taskStartedAt, CancellationToken token = default(CancellationToken));
    }
}

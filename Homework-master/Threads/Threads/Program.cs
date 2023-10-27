using System;
using System.Threading;
using Threads.Workers;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading keyboard in thread
            Console.WriteLine("Hello Thread World!");
            using (var cts = new CancellationTokenSource())
            {
                var dispatcher = new Dispatcher(cts);
                dispatcher.AddWorker(new CyanWorker(TimeSpan.FromMilliseconds(100)));
                dispatcher.AddWorker(new GrayWorker(TimeSpan.FromMilliseconds(200)));
                dispatcher.AddWorker(new ReadKeyboardWorker(TimeSpan.FromMilliseconds(20)));
                dispatcher.StartWorkers();
                dispatcher.WaitWorkers();
                Thread.Sleep(1000);
            }
            Console.WriteLine("Bye bye Thread World!");


            // reading keyboard from main thread

            //Console.WriteLine("Hello Thread World!");
            //using (var cts = new CancellationTokenSource())
            //{
            //    var dispatcher = new Dispatcher(cts);
            //    dispatcher.AddWorker(new CyanWorker(TimeSpan.FromMilliseconds(100)));
            //    dispatcher.AddWorker(new GrayWorker(TimeSpan.FromMilliseconds(200)));
            //    dispatcher.StartWorkers();
            //    Console.ReadKey();
            //    cts.Cancel();
            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine("Bye bye Thread World!");



        }
    }
}

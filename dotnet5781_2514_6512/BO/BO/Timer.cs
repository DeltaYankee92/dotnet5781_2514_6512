using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace BO.BO
{
    public sealed class Timer
    {
        static BL.BLapi.IBL bl = BLapi.BLFactory.GetBL();
        static List<int[]> observers = null;
        static BackgroundWorker worker = null;

        public Timer()
        {
            if (observers == null)
            {
                observers = new List<int[]>();
            }
            if (worker == null)
            {
                worker = new BackgroundWorker();
                worker.DoWork += Start;
                worker.ProgressChanged += bl.getTimer();
                worker.WorkerSupportsCancellation = true;
                worker.WorkerReportsProgress = true;
            }
        }

        public static void Add(int[] observer)
        {
            observers.Add(observer);
        }

        public static void Remove(int observer)
        {
            worker.RunWorkerAsync();
        }

        public static void Start(object sender, DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                foreach (var bus in observers.ToList())
                {
                    bl.Tick(bus);
                    Thread.Sleep(1000);
                }
                worker.ReportProgress(1);
            }
            e.Cancel = true;
            return;
        }
    }


}

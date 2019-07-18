using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThreadPool : ISingleReminder
    {
      
        public int Delay { get; set; }

        public string Msg { get; set; }
        public SingleReminderThreadPool(string msg,int delay)
        {
            Delay = delay;
            Msg = msg;
        }
        public event Action<string> Reminder;

        public void Start()
        {
            Delay = 100;
            Thread.Sleep(Delay + 100);
            ThreadPool.QueueUserWorkItem((o) => Reminder(Msg));
        }
    }
}
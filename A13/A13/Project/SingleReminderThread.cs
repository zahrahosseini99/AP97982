using System;
using System.Threading;
using System.Threading.Tasks;
namespace A13
{
    public class SingleReminderThread : ISingleReminder
    {
       public Thread ReiminderThread = null;
       
        public int Delay { get; set; }

        public string Msg { get; set; }
        public SingleReminderThread(string msg, int delay)
        {
            Delay = delay;
            Msg = msg;
        }
        public event Action<string> Reminder;

        public void Start()
        {
            Delay = 100;
            Thread.Sleep(Delay + 100);
            ReiminderThread = new Thread(()=>Reminder(Msg));
            ReiminderThread.Start();
        }
    }
}
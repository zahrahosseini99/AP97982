using System;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class SingleReminderTask : ISingleReminder
    {
        public int Delay { get; set; }
        public string Msg { get; set; }
      public  Task ReiminderTask = null;
        public SingleReminderTask(string msg,int delay)
        {
            Msg = msg;
            Delay = delay;
        }
        
        public event Action<string> Reminder;

        public void Start()
        {
            ReiminderTask = new Task(() => Reminder(Msg));
            ReiminderTask.Start();
        }
    }
}
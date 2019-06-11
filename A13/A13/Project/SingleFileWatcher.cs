using System;
using System.IO;
namespace A13
{

    public class SingleFileWatcher : IDisposable
    {

        public FileSystemWatcher Watcher = new FileSystemWatcher();
    
       
        public Action a;
       
        public SingleFileWatcher(string path)
        {
     Watcher = new FileSystemWatcher(@"C:\git\AP97982\A13\A13Tests\bin\Debug", Path.GetFileName(path));
  }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            a();
        }



        public void Register(Action p)
        {
            Watcher.EnableRaisingEvents = true;
            a += p;
            Watcher.Changed += Watcher_Changed;
        }
        public void Unregister(Action p)
        {
            Watcher.EnableRaisingEvents = true;
            a -= p;
        }
        public void Dispose()
        {
            
        }
    }
}
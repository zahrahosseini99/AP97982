using System;
using System.IO;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
       public  Action<string> a;
        public FileSystemWatcher Watcher = new FileSystemWatcher();
        public DirectoryWatcher(string dir)
        {
            Watcher = new FileSystemWatcher(dir);
        }
        public void Register(Action<string> p,ObserverType b)
        {
            Watcher.EnableRaisingEvents = true;

            if (b == 0)
            {
                a += p;
                Watcher.Created += Watcher_Created;
            }
        
            if (b == ObserverType.Delete)
            {
                a += p;
                Watcher.Deleted += Watcher_Deleted;
            }
               
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            a(e.FullPath);
        }
        public void Unregister(Action<string> p, ObserverType b)
        {
            Watcher.EnableRaisingEvents = true;
            if (b == 0)
            {
                a -= p;
             
            }

        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            a(e.FullPath);
        }

        public void Dispose()
        {
         
        }
    }
}
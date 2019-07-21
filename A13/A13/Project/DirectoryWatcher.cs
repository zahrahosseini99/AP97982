using System;
using System.IO;

namespace A13
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        public Action<string> Make;
        public Action<string> Remove;
        public FileSystemWatcher Watcher;
        public DirectoryWatcher(string dir)
        {
            Watcher = new FileSystemWatcher(dir);
            Watcher.EnableRaisingEvents = true;
        }
        public void Register(Action<string> p, ObserverType b)
        {


            if (b == 0)
            {
                Make += p;
                Watcher.Created += Watcher_Created;
            }

            if (b == ObserverType.Delete)
            {
                Remove += p;
                Watcher.Deleted += Watcher_Deleted;
            }

        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Make(e.FullPath);
        }
        public void Unregister(Action<string> p, ObserverType b)
        {
            Watcher.EnableRaisingEvents = true;
            if (b == 0)
            {
                Make -= p;

            }

        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Remove(e.FullPath);
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }
    }
}
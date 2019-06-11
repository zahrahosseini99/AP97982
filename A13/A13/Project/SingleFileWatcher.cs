using System;
using System.IO;
namespace A13
{

    public class SingleFileWatcher : IDisposable
    {

        public FileSystemWatcher Watcher = new FileSystemWatcher();
    
       
        public Action newAction;
       
        public SingleFileWatcher(string path)
        {
            int index = path.LastIndexOf('\\');
            string new_path = path.Substring(0, index);
            Watcher = new FileSystemWatcher(new_path, Path.GetFileName(path));
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            newAction();
        }



        public void Register(Action action)
        {
            Watcher.EnableRaisingEvents = true;
            newAction += action;
            Watcher.Changed += Watcher_Changed;
        }
        public void Unregister(Action action)
        {
            Watcher.EnableRaisingEvents = true;
            newAction -= action;
        }
        public void Dispose()
        {
            
        }
    }
}
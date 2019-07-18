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
        
            Watcher = new FileSystemWatcher(Path.GetDirectoryName(path), Path.GetFileName(path));
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += Watcher_Changed;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            newAction?.Invoke();


        }



        public void Register(Action action)
        {
           
            newAction += action;
     
        }
        public void Unregister(Action action)
        {
            Watcher.EnableRaisingEvents = true;
            newAction -= action;
        }
        public void Dispose()
        {
            Watcher.Dispose();
        }
    }
}
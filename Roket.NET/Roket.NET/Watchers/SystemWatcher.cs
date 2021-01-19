using System;
using System.Diagnostics;
using System.IO;

namespace Roket.NET.Watchers
{
    public abstract class SystemWatcher 
    {
        public FileSystemWatcher Watcher { get; set; }

        public SystemWatcher() => 
            Watcher = new FileSystemWatcher();    
        

        public void MonitorDirectory(string path, string filter, bool includeSubdirectories, NotifyFilters notify)
        {
            try
            {
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = @$"{path}",
                    Filter = filter ?? "*.txt",
                    IncludeSubdirectories = includeSubdirectories,
                    NotifyFilter = notify
                };
                watcher.Changed += FileWatcher_Changed;
                watcher.Renamed += FileWatcher_Renamed;
                watcher.Deleted += FileWatcher_Deleted;
                watcher.Created += FileWatcher_Created;
                watcher.Error += FileWatcher_Error;
                watcher.Disposed += FileWatcher_Disposed;

                watcher.EnableRaisingEvents = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

          
        }


        public abstract void FileWatcher_Changed(object sender, FileSystemEventArgs e);
        public abstract void FileWatcher_Renamed(object sender, FileSystemEventArgs e);
        public abstract void FileWatcher_Deleted(object sender, FileSystemEventArgs e);
        public abstract void FileWatcher_Created(object sender, FileSystemEventArgs e);
        public abstract void FileWatcher_Error(object sender, ErrorEventArgs e);
        public abstract void FileWatcher_Disposed(object sender, EventArgs e);

    }
}

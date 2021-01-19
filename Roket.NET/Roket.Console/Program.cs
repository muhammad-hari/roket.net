
using Roket.NET.Watchers;
using System;
using System.IO;
using System.Threading;

namespace Roket.Console
{


    class Program
    {


        static void Main(string[] args)
        {

            var monitor = new Monitor
            {
                position = 0
            };

            var path = File.ReadAllText($"{Path.GetFullPath(@"Roket.Config.txt")}");

            monitor.MonitorDirectory($@"{path}", "*.txt", false, NotifyFilters.LastAccess | NotifyFilters.LastWrite);

            System.Console.ReadLine();


        }
    }

    public class Monitor : SystemWatcher
    {
        public int position { get; set; } = 0;


        public override void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            System.Console.WriteLine($"\n\nThe Roket.Console Has Been Detected A Changes On");
            System.Console.WriteLine($"Name: {e.Name}");
            System.Console.WriteLine($"Location: {e.FullPath}");
            System.Console.WriteLine($"Changed At: {DateTime.Now.ToString("yyyy-MMM-dd hh:mm:ss")}\n\n\n");

            var path = File.ReadAllText($"{Path.GetFullPath(@"Roket.Config.txt")}");

            if(File.Exists(Path.Combine(path, e.Name)))
            {
                if(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), e.Name)))
                    File.Delete(Path.Combine(Directory.GetCurrentDirectory(), e.Name));
                
                File.Copy($"{Path.Combine(path, e.Name)}", Path.Combine(Directory.GetCurrentDirectory(), e.Name));

                FileStream stream = new FileStream($"{Path.Combine(Directory.GetCurrentDirectory(), e.Name)}", FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize:4096, useAsync: true);
                    
                using (var reader = (TextReader)new StreamReader(stream))
                {
                    stream.Seek(position, SeekOrigin.Current);

                    string lines = string.Empty;

                    while ((lines = reader.ReadLine()) != null)
                    {
                        position += lines.Length;

                        System.Console.WriteLine(lines);

                    }

                }
            }
            else
            {
                System.Console.WriteLine($"Cannot find any specific file on {path}");
            }




        }

        public override void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            System.Console.WriteLine($"The Roket.Console Has Been Detected A Created New File On");
            System.Console.WriteLine($"Name: {e.Name}");
            System.Console.WriteLine($"Location: {e.FullPath}");
            System.Console.WriteLine($"Change Type: {e.ChangeType}");
            System.Console.WriteLine($"Changed At: {DateTime.Now.ToString("yyyy-MMM-dd hh:mm:ss")}\n\n\n");
        }

        public override void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            System.Console.WriteLine($"The Roket.Console Has Been Detected A Deleted File On");
            System.Console.WriteLine($"Name: {e.Name}");
            System.Console.WriteLine($"Location: {e.FullPath}");
            System.Console.WriteLine($"Change Type: {e.ChangeType}");
            System.Console.WriteLine($"Changed At: {DateTime.Now.ToString("yyyy-MMM-dd hh:mm:ss")}\n\n\n");
        }

        public override void FileWatcher_Disposed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FileWatcher_Error(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void FileWatcher_Renamed(object sender, FileSystemEventArgs e)
        {
            System.Console.WriteLine($"The Roket.Console Has Been Detected A Renamed File On");
            System.Console.WriteLine($"Name: {e.Name}");
            System.Console.WriteLine($"Location: {e.FullPath}");
            System.Console.WriteLine($"Change Type: {e.ChangeType}");
            System.Console.WriteLine($"Changed At: {DateTime.Now.ToString("yyyy-MMM-dd hh:mm:ss")}\n\n\n");
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;
using System.Reflection;

namespace FilesChangesEventDemo.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int _nbChanges = 0;

        public MainWindowViewModel()
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            fileSystemWatcher.Filter = "log.txt";
            fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;

            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            NbChanges++;
        }
    }
}
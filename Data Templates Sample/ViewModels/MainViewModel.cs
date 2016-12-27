using Data_Templates_Sample.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System;
using Data_Templates_Sample.Views;
using System.Text;

namespace Data_Templates_Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ISetting> _settingsCollection = new ObservableCollection<ISetting>();

        public MainViewModel()
        {
            InitCollection();
        }

        private void InitCollection()
        {
            SettingsCollection.Add(new StringSetting
                { Name = "Author", Label = "Author", TextValue = "Registered User" }
            );

            SettingsCollection.Add(new StringSetting
            { Name = "Title", Label = "Title", TextValue = "Draft Letter" }
            );

            SettingsCollection.Add(new BooleanSetting
            { Name = "RemoveComments", Label = "Remove Comments", IsChecked = true }
            );

            SettingsCollection.Add(new BooleanSetting
            { Name = "RemoveHyperlinks", Label = "Remove Hyperlinks", IsChecked = true }
           );

            SettingsCollection.Add(new StringSetting
            { Name = "LastModifiedAuthor", Label = "Modified By", TextValue = "Michael Daniloff" }
           );

          //  SettingsCollection.Add(new StringSetting
          //  { Name = "Keywords", Label = "Keywords", TextValue = "Draft Proposal" }
          //);

          //  SettingsCollection.Add(new BooleanSetting
          //  { Name = "RemoveBookmarks", Label = "Remove Bookmarks", IsChecked = false }
          //);
        }

        public ObservableCollection<ISetting> SettingsCollection
        {
            get
            {
                return _settingsCollection;
            }

            set
            {
                _settingsCollection = value;
                OnPropertyChanged("SettingsCollection");
            }
        }
        
        private RelayCommand _LaunchCommand;

        public ICommand LaunchCommand
        {
            get
            {
                if (_LaunchCommand == null)
                {
                    _LaunchCommand = new RelayCommand(
                        p => OnLaunchCommand(),
                        p => CanLaunchCommand);
                }

                return _LaunchCommand;
            }
        }

        public bool CanLaunchCommand
        {
            get
            {
                return true;
            }
        }

        private void OnLaunchCommand()
        {
            SettingsView view = new SettingsView();
            SettingsViewModel viewModel = new SettingsViewModel();
            viewModel.SettingsCollection = SettingsCollection;
            view.DataContext = viewModel;
            viewModel.OnRequestClose += (t, e) => view.Close();
            view.ShowDialog();

            if (viewModel.OkayClicked)
            {
                UpdateDisplay();
            }
        }

        private string _display;
        public string Display
        {
            get
            {
                return _display;
            }

            set
            {
                _display = value;
                OnPropertyChanged("Display");
            }
        }
        private void UpdateDisplay()
        {
            StringBuilder sb = new StringBuilder();
            
            var items = SettingsCollection.Where(e => e.IsModified);

            foreach (var item in items)
            {
                sb.Append(item.Label.ToUpper());

                if (item is StringSetting)
                {
                    StringSetting ss = item as StringSetting;
                    sb.Append(": ");
                    sb.Append(ss.TextValue);
                }
                else
                {
                    BooleanSetting bs = item as BooleanSetting;
                    if (bs.IsChecked)
                        sb.Append(": Checked");
                    else
                        sb.Append(": Unchecked");
                }
                sb.Append(Environment.NewLine);
            }

            Display = sb.ToString();
        }
    }
}

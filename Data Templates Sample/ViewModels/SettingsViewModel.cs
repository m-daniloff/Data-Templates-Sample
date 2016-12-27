using Data_Templates_Sample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data_Templates_Sample.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private ObservableCollection<ISetting> _settingsCollection;

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

        private RelayCommand _AcceptCommand;

        public ICommand AcceptCommand
        {
            get
            {
                if (_AcceptCommand == null)
                {
                    _AcceptCommand = new RelayCommand(
                        p => OnAcceptCommand(),
                        p => CanAccept);
                }

                return _AcceptCommand;
            }
        }

        public bool CanAccept
        {
            get
            {
                return true;
            }
        }

        private void OnAcceptCommand()
        {
            OkayClicked = true;
        }
              
        public bool OkayClicked { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Data_Templates_Sample.Models
{
    public interface ISetting
    {
        string Name { get; set; }

        string Label { get; set; }

        bool IsModified { get; set; }
    }

    public class StringSetting : ISetting, INotifyPropertyChanged
    {

        private bool _isModified;
        public bool IsModified
        {
            get
            {
                return _isModified;
            }

            set
            {
                _isModified = value;
            }
        }

        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }

            set
            {
                _label = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string _textValue;

        public string TextValue
        {
            get
            {
                return _textValue;
            }

            set
            {
                _textValue = value;
                OnPropertyChanged("TextValue");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                _isModified = true;
            }
        }
    }

    public class BooleanSetting : ISetting, INotifyPropertyChanged
    {
        private bool _isModified;
        public bool IsModified
        {
            get
            {
                return _isModified;
            }

            set
            {
                _isModified = value;
            }
        }

        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }

            set
            {
                _label = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        private bool _checked;
        public bool IsChecked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;    
                OnPropertyChanged("IsChecked");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                _isModified = true;
            }                
        }
    }
}

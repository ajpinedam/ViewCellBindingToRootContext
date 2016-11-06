using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListNavigationForms
{
    public class ListNavigationFormsViewModel : INotifyPropertyChanged
    {
        private string _buttonListName;
        public string ButtonListName
        {
            get { return _buttonListName; }
            set
            {
                if (_buttonListName == value)
                    return;

                _buttonListName = value;
                NotifyPropertyChanged (nameof(ButtonListName));
            }
        }

        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                if (_header == value)
                    return;

                _header = value;
                NotifyPropertyChanged (nameof (Header));
            }
        }

        private string _footer;
        public string Footer
        {
            get { return _footer; }
            set
            {
                if (_footer == value)
                    return;

                _footer = value;
                NotifyPropertyChanged (nameof (Footer));
            }
        }

        public ICommand ClickCommand { get; private set;}

        public ObservableCollection<Thing> BunchOfThings { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }

        List<Thing> _testThings;

        public ListNavigationFormsViewModel ()
        {
            _testThings = new List<Thing>
            {
                new Thing{ Id="1", Description="Xamarin Forms", Name="Forms" } ,
                new Thing{ Id="2", Description="Xamarin Android", Name="Android" },
                new Thing{ Id="3", Description="Xamarin IOS", Name="IOS" }
            };

            ClickCommand = new Command ((obj) => {
                Footer = $"Was clicked from the Item Cell with Name: {((Thing)obj)?.Name}";
            });

            BunchOfThings = new ObservableCollection<Thing> ();

            ButtonListName = "Click Me!!";

            Header = "Test XAML binding ROOT";
        }

        public void LoadThing ()
        {
            foreach (var item in _testThings)
            {
                BunchOfThings.Add (item);
            }
        }
    }
}
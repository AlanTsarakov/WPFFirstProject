using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfFirstProject.Models;

namespace WpfFirstProject.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MainButton _mainButton;
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<User> Users { get; set; }
        public ICommand ClickCommand { get; }
        public ICommand ResetCommand { get; }

        public int CountClicks { 
            get 
            { 
                return _mainButton.CountClicks;
            }
            set
            {  
                _mainButton.CountClicks = value;
                OnPropertyChanged(nameof(CountClicks));
            }
        }

        public void ExecuteReset()
        {
            CountClicks = 0;
        }
        public void ExecuteClick()
        {
            CountClicks++;
        }

        public MainWindowViewModel()
        {
            _mainButton = new MainButton();
            ClickCommand = new RelayCommand(ExecuteClick);
            ResetCommand = new RelayCommand(ExecuteReset);
            Users = new ObservableCollection<User>() { 
                new User(1, "Алан", "negra@gmail.com", "привет. давай знакомиться"), 
                new User(2, "Гэтсби", "gatsby@gmail.com", "Старина, рад видеть на моей странице"),
                new User(3, "Бегемот", "beegemot@gmail.com", "Гав-гав")
            };

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

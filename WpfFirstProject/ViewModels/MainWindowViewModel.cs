using System;
using System.Collections.Generic;
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

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

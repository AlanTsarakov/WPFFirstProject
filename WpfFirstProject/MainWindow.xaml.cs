using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfFirstProject.ViewModels;

namespace WpfFirstProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clickCount = 0;
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Start();
            DataContext = new MainWindowViewModel();
            var btn = new Button() { Width = 20, Height = 20, HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(btn);
            btn.Click += Btn_Click;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int rndInt = random.Next(1, 100);

            if (rndInt%2 == 0)
            {
                mainWindowGrid.Background = Brushes.Red;
            }
            else
            {
                mainWindowGrid.Background = Brushes.Gainsboro;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            clickCount++;
            progressBar.Value = Convert.ToDouble(clickCount);
            progressBar.Visibility = Visibility.Visible;
            progressBar.UpdateLayout();

            Button btn = (Button)sender;
            if (clickCount % 2 == 0)
            {
                btn.Background = Brushes.Red;
            }
            else
            {
                btn.Background = Brushes.Green;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            SecondTestWindow second = new SecondTestWindow();
            second.ShowDialog();
        }
    }
}
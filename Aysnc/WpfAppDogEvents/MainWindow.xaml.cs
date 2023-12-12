using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using DogLibraryDotNet;

namespace WpfAppDogEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DogLongBark dog;

        

        public MainWindow()
        {
            dog = new DogLibraryDotNet.DogLongBark();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();

            InitializeComponent();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            progBar.Value -= 1;
            if (progBar.Value <= 0) progBar.Value = 100;
        }

        private void btnDogBarkSync_Click(object sender, RoutedEventArgs e)
        {

            tbOut.Text += "\n" + dog.Bark() + " " + System.DateTime.Now.ToLongTimeString();
        }

        private async void btnDogBarkASync_Click(object sender, RoutedEventArgs e)
        {

            string bark = await DogBarkASync(dog);
            tbOut.Text += "\n" + bark  + " " + System.DateTime.Now.ToLongTimeString();
        }


        static async Task<string> DogBarkASync(DogLongBark dog)
        {
            string bark = await Task.FromResult(dog.Bark());
            return bark;
        }

        private async void btnDogBarkASyncTask_Click(object sender, RoutedEventArgs e)
        {
            string bark = await Task<String>.Run(() => dog.Bark());
            tbOut.Text += "\n" + bark + " " + System.DateTime.Now.ToLongTimeString();


        }
    }
}

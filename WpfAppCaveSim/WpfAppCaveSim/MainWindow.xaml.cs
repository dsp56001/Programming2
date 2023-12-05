using ConsoleCaveSim.Models;
using ConsoleCaveSim.Models.Consumers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppCaveSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cave sim;
        ObservableCollection<Bat> obats;
        
        public MainWindow()
        {
            InitializeComponent();
            sim = new Cave();
            UpdateUI();
        }

        private void btnTick_Click(object sender, RoutedEventArgs e)
        {
            sim.Tick();
            UpdateUI();
        }

        private void UpdateUI()
        {
            obats = new ObservableCollection<Bat>(sim.Items.OfType<Bat>().ToList());
            lbBats.DataContext = obats; //hack need viewmodel
            lbCornCount.Content = sim.CornCount.ToString();
        }

        private void btnNewCave_Click(object sender, RoutedEventArgs e)
        {
            sim = new Cave(int.Parse(tbBats.Text), int.Parse(tbCorn.Text));
            UpdateUI();
        }
    }
}

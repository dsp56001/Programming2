using ConsoleAppCrafting.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Threading;
using WpfAppCrafting.Models.UI;

namespace WpfAppCrafting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIApplication app;

        DispatcherTimer timer;


        public MainWindow()
        {
            InitializeComponent();
            app = new UIApplication();
            app.GiveThreeItems(); //don't start with empty inventory should give something to start with
            UpdateUI();

            TimeSpan timeSpan;
            timeSpan = TimeSpan.FromSeconds(60);

            timer = new DispatcherTimer(
                new TimeSpan(0, 0, 1),
                DispatcherPriority.Normal,
                delegate
                {
                    
                    //run on every call back
                    lblTime.Content = (timeSpan).ToString("c");
                    if (timeSpan == TimeSpan.Zero)
                    {
                        timeSpan = TimeSpan.FromSeconds(61);
                        //Timeout
                        
                        app.GiveThreeItems();
                        UpdateUI();
                    }
                    timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                },
                Application.Current.Dispatcher);
            timer.Stop();
            
        }

        private void UITimer_UITimerTick(object? sender, EventArgs e)
        {
            
              //UpdateUI();
            
        }

        /// <summary>
        /// Updates the UI from the app class
        /// </summary>
        private void UpdateUI()
        {
            //Clear UIItems
            cCraftingInventory.Items.Clear();
            cInventory.Items.Clear();
            cRecipe.Items.Clear();
            //Add items to invetory items
            foreach(var item in app.Customer.InventoryItems)
            {
                cInventory.Items.Add(item.Name);
            }
            //Add items to craft items
            foreach (var item in app.Customer.CraftItems)
            {
                cCraftingInventory.Items.Add(item.Name);
            }

            //update recipes enable the recipes that are possible to craft
            foreach (var item in app.Recipes.Recipes )
            {
                //make and setup a new comboboxitem
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item.Name;
                //Disable combobox item will enable if we can craft from the inventory
                comboBoxItem.IsEnabled = false; 
                if (app.Customer.CanCraft(item)) 
                { comboBoxItem.IsEnabled = true; }
                
                //Add to combobox
                cRecipe.Items.Add(comboBoxItem);
            }

            
        }

        private void btnAddToCraftingInventory_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = string.Empty;
            if(cInventory.SelectedValue == null)
            {
                MessageBox.Show("No Item Selected");
                return;
            }
            //Use value none if no value
            selectedItem = cInventory.SelectedItem.ToString() ?? "none";
            
            IItem item = app.Supplier.GetItem(selectedItem);
            app.Customer.MoveItemToCraftingItemsFromInveroty(item.Name);
            
            UpdateUI();
        }

        private void btnRemoveFromCraftingInventory_Click(object sender, RoutedEventArgs e)
        {
            if (cCraftingInventory.SelectedValue == null)
            {
                MessageBox.Show("No Item Selected");
                return;
            }

            app.Customer.MoveItemToInventoryFromCraftingItems(cCraftingInventory.SelectedValue.ToString() ?? "none");
            
            UpdateUI();      
        }

        private void btnCraft_Click(object sender, RoutedEventArgs e)
        {
            if (cRecipe.SelectedValue == null)
            {
                MessageBox.Show("No Recipe Selected");
                return;
            }
            ListBoxItem selectedItem = (ListBoxItem)cRecipe.SelectedValue;
            IRecipe recipe = app.Supplier.GetRecipe(selectedItem.Content.ToString() ?? "none");
            app.Customer.Craft(recipe);
            
            UpdateUI();
        }

        private void btnTimerToggle_Click(object sender, RoutedEventArgs e)
        {
            if(timer.IsEnabled)
            {
                timer.Stop();
                btnTimerToggle.Content = "Timer Start";
                return;
            }
            timer.Start();
            btnTimerToggle.Content = "Timer Stop";
        }

        private void btnGimmeStuff_Click(object sender, RoutedEventArgs e)
        {
            app.GiveRandom();
            UpdateUI();
        }
    }
}

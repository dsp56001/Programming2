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
using WpfAppCrafting.Models.UI;

namespace WpfAppCrafting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIApplication app;
        public MainWindow()
        {
            InitializeComponent();
            app = new UIApplication();
            app.GiveThreeItems(); //don't start with empty inventory should give something to start with
            UpdateUI();
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
                ListBoxItem listBoxItem = new ListBoxItem() { Content= item.Name };
                
                //Fancy colors
                if (item is Dye)
                {
                    listBoxItem.Background = new SolidColorBrush() { Color = System.Windows.Media.Color.FromRgb(((Dye)item).Color.R, ((Dye)item).Color.G, ((Dye)item).Color.B )};
                }
                cInventory.Items.Add(listBoxItem);
                //cInventory.Items.Add(item.Name);

                
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
    }
}

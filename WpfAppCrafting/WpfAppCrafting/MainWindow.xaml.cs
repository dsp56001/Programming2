using ConsoleAppCrafting.Models;
using System;
using System.Collections.Generic;
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
            app.GiveThreeItems();
            UpdateUI();
        }

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

            //TODO this is a waste to update all the time maybe try to update once
            foreach (var item in app.Recipes.Recipes )
            {
                //make and setup comboboxitem
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

        //TODO clean up warnings
        private void btnAddToCraftingInventory_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = string.Empty;
            if(cInventory.SelectedValue == null)
            {
                MessageBox.Show("No Item Selected");
                return;
            }
            //Use value none if no value
            selectedItem = cInventory.SelectedValue.ToString() ?? "none";
            
            
            IItem item = app.Supplier.GetIngredient(selectedItem);
            app.Customer.AddToCraftingItem(item.Name);
            UpdateUI();
        }

        private void btnRemoveFromCraftingInventory_Click(object sender, RoutedEventArgs e)
        {
            if (cCraftingInventory.SelectedValue == null)
            {
                MessageBox.Show("No Item Selected");
                return;
            }

            app.Customer.RemoveFromCraftingItems(cCraftingInventory.SelectedValue.ToString() ?? "none");
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

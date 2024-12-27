using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Products_ListView_Management
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        List<Product> products = new List<Product> ();
        Product selectedProduct = null;

        public ProductPage()
        {
            InitializeComponent();
            ProductListView.ItemsSource = products; //**Link List to ListView and display the List
        }

        //Add Product
        private void OnAddProductClicked(Object sender, EventArgs e)
        {
            String ProductName = ProductNameEntry.Text;
            String ProductDescription= ProductDescriptionEntry.Text;

            if (!String.IsNullOrEmpty(ProductName) && !String.IsNullOrEmpty(ProductDescription))
            {
                products.Add(new Product{ Name = ProductName, Description = ProductDescription });
                RefreshListView();
                ClearEntryFields();                
            }
            else
            {
                DisplayAlert("Error", "Please enter name and description", "OK");
            }
        }

        //Product selection from ListView
        private void OnProductSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            selectedProduct = e.SelectedItem as Product;
            if (selectedProduct != null)
            {
                ProductNameEntry.Text = selectedProduct.Name;
                ProductDescriptionEntry.Text = selectedProduct.Description;
            }
        }
        
        //Delete selected product
        private void OnDeleteProductClicked(Object sender, EventArgs e)
        {
            if (selectedProduct !=null)
            {
                products.Remove(selectedProduct);
                RefreshListView(); 
                ClearEntryFields();
                selectedProduct = null;
            }
            else
            {
                DisplayAlert("Error", "Please select a product to delete", "OK");
            }
        }

        //Edit selected product
        private void OnEditProductClicked(Object sender, EventArgs e)
        {
            if (selectedProduct != null)
            {
                selectedProduct.Name = ProductNameEntry.Text;
                selectedProduct.Description = ProductDescriptionEntry.Text;
                RefreshListView();
                ClearEntryFields();
                selectedProduct = null;
            }
            else
            {
                DisplayAlert("Error", "Please select a product to edit", "OK");
            }
        }

        //Empty fields
        private void ClearEntryFields()
        {
            ProductNameEntry.Text = "";
            ProductDescriptionEntry.Text= "";
        }

        //refresh listView after modification
        private void RefreshListView()
        {
            ProductListView.ItemsSource = null;
            ProductListView.ItemsSource = products;
        }
    }
}
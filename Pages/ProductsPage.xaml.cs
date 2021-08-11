using Project.Models;
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

namespace Project.Pages
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            syncDB();
        }


        private void goBack(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void syncDB()
        {
            using var dbContext = new SqliteDBContext();
            var categories = dbContext.Categories.ToList<Category>();
            if (categories is not null)
            {
                catPCB.ItemsSource = categories.Select(c => c.CategoryName);
            }
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            if(catPCB.SelectedItem is not -1 & NewProductName.Text is not "")
            {
                using var dbContext = new SqliteDBContext();
                Category cat = dbContext.Categories.Where(c => c.CategoryName == catPCB.Text).First();
                cat.Products.Add(new() { ProductName = NewProductName.Text, ProductPrice = NewProductPrice.Text });
                //Converting String of the price to double
                dbContext.SaveChanges();
                catPCB.SelectedIndex = -1;
                NewProductName.Text = "";
                _ = this.NavigationService.Navigate(new MainPage());
            }
        }
    }
}

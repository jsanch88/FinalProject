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
    /// Interaction logic for ShoppingPage.xaml
    /// </summary>
    public partial class ShoppingPage : Page
    {
        public ShoppingPage()
        {
            InitializeComponent();
            syncDB();
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            _ = this.NavigationService.Navigate(new MainPage());
        }
        private void syncDB()
        {
            using var dbContext = new SqliteDBContext();
            var categories = dbContext.Categories.ToList<Category>();
            /*if (categories is not null)
            {
                catMCB.ItemsSource = categories.Select(c => c.CategoryName);
            }*/
            //using var dbContext = new SqliteDBContext();
            var products = dbContext.Products.ToList<Product>();
            if (products is not null)
            {
                productMCB.ItemsSource = products.Select(p => p.ProductName);
            }    


        }

        private void addToCart(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Added to cart");
        }

        /*private void SyncDG(object sender, SelectionChangedEventArgs e)
        {
            using var dbContext = new SqliteDBContext();
            Category cat = dbContext.Categories.Where(c => c.CategoryName == catMCB.SelectedItem.ToString()).First();
            List<Product> pList = dbContext.Products.Where(p => p.CategoryId == cat.CategoryId).ToList<Product>();
        }*/

        private void SyncProducts(object sender, SelectionChangedEventArgs e)
        {
            using var dbContext = new SqliteDBContext();
            Product cat = dbContext.Products.Where(p => p.ProductName == productMCB.SelectedItem.ToString()).First();
            //List<Product> pList = dbContext.Products.Where(c => c.ProductId == cat.ProductId).ToList<Category>();
            
        }
    }
}

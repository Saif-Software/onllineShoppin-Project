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

namespace onllineShopping
{
    
    public partial class ShowProducts : Page
    {
        onllineShoppingEntities db = new onllineShoppingEntities();
        public ShowProducts()
        {
            InitializeComponent();
            dgrid.ItemsSource = db.products.Select(x => new { x.productId, x.Names, x.price }).ToList();
        }

       
        private void addtocart(object sender, RoutedEventArgs e)
        {
            user user = new user();
            order or = new order();
            product pro = new product();

            int id = int.Parse(txtprduectid.Text);

            pro = db.products.FirstOrDefault(x => x.productId == id);

            or.product.Names = pro.Names;
            or.products_ID = pro.productId;
            or.users_ID = user.userId;

            
            db.orders.Add(or);
            db.SaveChanges();

            cart cart = new cart(or);
            NavigationService.Navigate(cart);
        }


    }
}

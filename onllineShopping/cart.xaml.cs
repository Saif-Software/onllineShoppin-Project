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
    /// <summary>
    /// Interaction logic for cart.xaml
    /// </summary>
    public partial class cart : Page
    {
        onllineShoppingEntities db = new onllineShoppingEntities();
        public cart(order order)
        {
            InitializeComponent();

            dgrid.ItemsSource = db.orders.Select(x => new {x.orderID,x.products_ID,x.product.Names ,}).ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for adminPage.xaml
    /// </summary>
    public partial class adminPage : Page
    {
        onllineShoppingEntities db = new onllineShoppingEntities();
        public adminPage()
        {
            InitializeComponent();
            dgrid.ItemsSource = db.products.Select(x => new {x.productId,x.Names,x.price}).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            product pro = new product();
            pro.Names = txtname.Text;
            pro.price = int.Parse(txtprice.Text);

            db.products.Add(pro);
            db.SaveChanges();
            dgrid.ItemsSource = db.products.Select(x => new { x.productId, x.Names, x.price }).ToList();
        }
    }
}

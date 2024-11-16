using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        onllineShoppingEntities db = new onllineShoppingEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void loginn(object sender, RoutedEventArgs e)
        {
            var rec = db.users.FirstOrDefault(x => x.Names == txtname.Text && x.passwords == txtapassword.Password);
           
            if(rec!=null)
            {
                    MessageBox.Show("Login Success");
                    ShowProducts showProducts = new ShowProducts();
                    NavigationService.Navigate(showProducts);
            }
            else if(txtname.Text == "1" && txtapassword.Password == "1")
            {
                MessageBox.Show("admin Login success");
                adminPage adminPage = new adminPage();
                NavigationService.Navigate(adminPage);
            }
            else
            {
                MessageBox.Show("invaild data");
            }
        }
        private void signup(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            NavigationService.Navigate(signup);
        }

        private void Forget_Pass(object sender, RoutedEventArgs e)
        {
            forgetPass forgetPass = new forgetPass();
            NavigationService.Navigate(forgetPass);
        }
    }
}
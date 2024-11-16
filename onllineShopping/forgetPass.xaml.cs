using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for forgetPass.xaml
    /// </summary>
    public partial class forgetPass : Page
    {
        onllineShoppingEntities db = new onllineShoppingEntities();
        public forgetPass()
        {
            InitializeComponent();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(emailTxt.Text) || string.IsNullOrEmpty(passTxt.Password) || string.IsNullOrEmpty(txtconpass.Password))
            {
                MessageBox.Show("required feild");
            }
            else if (passTxt.Password != txtconpass.Password)
            {
                MessageBox.Show("password didnt match");
            }
            else
            {
                var rec = db.users.First(x => x.Email == emailTxt.Text);
                if (rec != null && passTxt.Password == txtconpass.Password)
                {
                    rec.passwords = passTxt.Password;
                    db.users.AddOrUpdate(rec);
                    db.SaveChanges();
                    MessageBox.Show("Password updated successfully");
                }
            }
           
        }
    }
           
}
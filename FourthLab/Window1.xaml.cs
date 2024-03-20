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
using System.Windows.Shapes;

namespace FourthLab
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private CircusEntities context = new CircusEntities();

        public Window1()
        {
            InitializeComponent();
            EF.ItemsSource = context.Customers.ToList();
            EmailCbx.ItemsSource = context.Emails.ToList();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            EF.ItemsSource = context.Customers.ToList().Where(item => item.Firstname.Contains(Text.Text));
            EF.ItemsSource = context.Customers.ToList().Where(item => item.Surname.Contains(Text.Text));
        }

        private void EmailCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmailCbx.SelectedItem != null)
            {
                var selected = EmailCbx.SelectedItem as Emails;
                EF.ItemsSource = context.Customers.ToList().Where(item => item.Emails == selected);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            EF.ItemsSource = context.Customers.ToList();
        }
    }
}

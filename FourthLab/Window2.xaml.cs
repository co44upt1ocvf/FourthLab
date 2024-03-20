using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using FourthLab.CircusDataSetTableAdapters;

namespace FourthLab
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        CustomersTableAdapter Customers = new CustomersTableAdapter();
        EmailsTableAdapter Emails = new EmailsTableAdapter();

        public Window2()
        {
            InitializeComponent();

            DataSet.ItemsSource = Customers.GetData();
            EmailCbx.ItemsSource = Emails.GetData();
        }
        private void SearchByName(object sender, RoutedEventArgs e)
        {
            DataSet.ItemsSource = Customers.SearchByName(Text.Text);
        }

        private void SearchBySurname(object sender, RoutedEventArgs e)
        {
            DataSet.ItemsSource = Customers.SearchBySurname(Text.Text);
        }

        private void EmailCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmailCbx.SelectedItem != null)
            {
                var id = (int)(EmailCbx.SelectedItem as DataRowView).Row[0];
                DataSet.ItemsSource = Customers.Filter(id);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            DataSet.ItemsSource = Customers.GetData();
        }
    }
}

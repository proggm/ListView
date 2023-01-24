using ListView.Context;
using ListView.Model;
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

namespace ListView.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

      

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListView.ItemsSource = AppData.db.InfoUser.ToList();
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Dobbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionPage(new Model.InfoUser()));
        }

        private void Redbtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (InfoUser)ListView.SelectedItem;
            if(selectedItem != null)
            {
                NavigationService.Navigate(new ActionPage(selectedItem));
            }
        }

        private void DeleBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (InfoUser)ListView.SelectedItem;
            if(selectedItem != null)
            {
                AppData.db.InfoUser.Remove(selectedItem);
                AppData.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Данные удалены","Успешно!",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void txb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = AppData.db.InfoUser.Where(item => item.ID.ToString().Contains(txb1.Text)).ToList();
        }
    }
}

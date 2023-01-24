using ListView.Context;
using ListView.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListView.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ActionPage.xaml
    /// </summary>
    public partial class ActionPage : Page
    {
        public InfoUser InfoUser { get; set; }
        public ActionPage(InfoUser InfoUser)
        {
            InitializeComponent();
            this.InfoUser = InfoUser;
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(InfoUser.ID == 0)
            {
                AppData.db.InfoUser.Add(InfoUser);
            }
            File.Copy(file.FileName,$"Photos\\{System.IO.Path.GetFileName(file.FileName).Trim()}",true);
            InfoUser.GetPhoto = "\\Photos\\" + System.IO.Path.GetFileName(file.FileName);
            AppData.db.SaveChanges();
            MessageBox.Show("Данные сохранены","Успешно!",MessageBoxButton.OK,MessageBoxImage.Information);
            NavigationService.GoBack();
        }
        OpenFileDialog file = new OpenFileDialog();
        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            file.Filter = "Image(*.jpg;*.jpeg;*.png;) | *.jpg;*.jpeg;*.png";
            if(file.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(file.FileName));
                Pic.Source = image;
            }    
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

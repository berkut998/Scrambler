using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clone_CryptaTool
{
    /// <summary>
    /// Логика взаимодействия для allScrumbler.xaml
    /// </summary>
    public partial class allScrumbler : Page
    {
        public allScrumbler()
        {
            InitializeComponent();
        }
        private void Button_decode_Click(object sender, RoutedEventArgs e)
        {
            presenter.decode();
            TextBox_Cipher.IsEnabled = true;
        }
        private void Button_Encode_Click(object sender, RoutedEventArgs e)
        {
            presenter.encode();
            TextBox_Cipher.IsEnabled = true;
        }
    }
}

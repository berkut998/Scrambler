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
using Clone_CryptaTool.Interface;

namespace Clone_CryptaTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private Presenter presenter;

        public string beforeText { get => TextBox_NotCipher.Text; set => TextBox_NotCipher.Text = value; }
        public string afterText { get => TextBox_Cipher.Text; set => TextBox_Cipher.Text = value; }
        public string keyWord { get => TextBox_key.Text; set => TextBox_key.Text = value; }
        public byte currentOperation { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        private void Button_Encode_Click(object sender, RoutedEventArgs e)
        {
            presenter.encode();
            TextBox_Cipher.IsEnabled = true;
        }

        private void choose_Cipher_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item.Name == "MenuItem_Atbash")
            {
                currentOperation = 0;
                TextBox_key.Visibility = Visibility.Collapsed;
            } 
            if (item.Name == "MenuItem_Vigener")
            { 
                currentOperation = 1;
                TextBox_key.Visibility = Visibility.Visible;
            }
            if (item.Name == "MenuItem_Fetiel")               
            {
                currentOperation = 2;
                TextBox_key.Visibility = Visibility.Visible;
            }
            if (item.Name == "MenuItem_deffi_helman")
            { 
                currentOperation = 3;
                this.Content = new OpenKey_Page();
            }
            if (item.Name == "MenuItem_random_generator")
            {
                currentOperation = 4;
                TextBox_key.Visibility = Visibility.Visible;
            }
        }

        private void Button_decode_Click(object sender, RoutedEventArgs e)
        {
            presenter.decode();
            TextBox_Cipher.IsEnabled = true;
        }

      
    }
}

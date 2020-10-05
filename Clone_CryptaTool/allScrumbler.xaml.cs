using Clone_CryptaTool.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Clone_CryptaTool
{
    /// <summary>
    /// Логика взаимодействия для allScrumbler.xaml
    /// </summary>
    public partial class allScrumbler : Page, IView_Scrambler_Page
    {
        private Presenter_Scrambler presenter;

        public string beforeText { get => TextBox_NotCipher.Text; set => TextBox_NotCipher.Text = value; }
        public string afterText { get => TextBox_Cipher.Text; set => TextBox_Cipher.Text = value; }
        public string keyWord { get => TextBox_key.Text; set => TextBox_key.Text = value; }
        public byte currentOperation { get; set; } = 0;
        public allScrumbler()
        {
            InitializeComponent();
            presenter = new Presenter_Scrambler(this);
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

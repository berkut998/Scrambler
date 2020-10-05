using Clone_CryptaTool.Interface;
using Clone_CryptaTool.Presenter;
using deffie_hellman;
using System.Windows;
using System.Windows.Controls;
using Vigener;

namespace Clone_CryptaTool
{
    /// <summary>
    /// Логика взаимодействия для OpenKey_Page.xaml
    /// </summary>
    public partial class OpenKey_Page : Page, IView_OpenKey_Page
    {
        OpenKey Alice_Open_key;
        OpenKey Bob_Open_key;
        Cipher_Vigener vigener = new Cipher_Vigener();
        private Presenter_OpenKey presenter_openKey;

        public string messageToUser1 { get => TextBox_Chat1.Text; set => TextBox_Chat1.Text += value.ToString() + "\n"; }
        public string messageToUser2 { get => TextBox_Chat2.Text; set => TextBox_Chat2.Text += value.ToString() + "\n"; }
        public string openKeyUser1 { get => TextBlock_Alice_Key.Content.ToString(); set => TextBlock_Alice_Key.Content = value.ToString(); }
        public string openKeyUser2 { get => TextBlock_Bob_Key.Content.ToString(); set => TextBlock_Bob_Key.Content = value.ToString(); }
        public string encryptedMessage_FromAlice { get => all__Message_box.Text; set => all__Message_box.Text += "Алиса: " + value.ToString() + "\n"; }
        public string encryptedMessage_FromBob { get => all__Message_box.Text; set => all__Message_box.Text += "Боб: " + value.ToString() + "\n"; }

        public string messageFromUser1 { get => TextBox_message_box1.Text; set => TextBox_message_box1.Text = value.ToString(); }
        public string messageFromUser2 { get => TextBox_message_box2.Text; set => TextBox_message_box2.Text = value.ToString(); }
        public OpenKey_Page()
        {
            InitializeComponent();
            presenter_openKey = new Presenter_OpenKey(this);
        }

        private void Bob_Message_button_Click(object sender, RoutedEventArgs e)
        {
            presenter_openKey.SendMessageFromBob();
        }

        private void Alice_Message_button_Click(object sender, RoutedEventArgs e)
        {
            presenter_openKey.SendMessageFromAllice();
        }
    }
}

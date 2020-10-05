using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Clone_CryptaTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new allScrumbler();
        }

        private void MenuItem_OpenScrumble_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            if (item.Name == "MenuItem_Atbash" || item.Name == "MenuItem_Vigener" || item.Name == "MenuItem_Fetiel")
            {
                allScrumbler scrumbler;
                if (ContentFrame.Content.GetType() != typeof(allScrumbler))
                {
                    scrumbler =  new allScrumbler();
                    ContentFrame.Content = scrumbler;
                }
                else
                    scrumbler = (allScrumbler)ContentFrame.Content;
                if (item.Name == "MenuItem_Atbash")
                {
                    scrumbler.currentOperation = 0;
                    scrumbler.TextBlock_cipherName.Text = "Атбаш";
                    scrumbler.TextBox_key.Visibility = Visibility.Collapsed;
                }
                if (item.Name == "MenuItem_Vigener")
                {
                    scrumbler.currentOperation = 1;
                    scrumbler.TextBlock_cipherName.Text = "Виженер";
                    scrumbler.TextBox_key.Visibility = Visibility.Visible;
                }
                if (item.Name == "MenuItem_Fetiel")
                {
                    scrumbler.currentOperation = 2;
                    scrumbler.TextBlock_cipherName.Text = "Фестель";
                    scrumbler.TextBox_key.Visibility = Visibility.Visible;
                }
            }
            if (item.Name == "MenuItem_deffi_helman")
            {
                OpenKey_Page open_page = new OpenKey_Page();
                ContentFrame.Content = open_page;
            }
            if (item.Name == "MenuItem_random_generator")
            {
                Page_RandomNumberGenerator page_random = new Page_RandomNumberGenerator();
                ContentFrame.Content = page_random;
            }
        }     
    }
}

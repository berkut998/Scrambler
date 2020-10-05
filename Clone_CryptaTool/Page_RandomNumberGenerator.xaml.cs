using Clone_CryptaTool.Interface;
using Clone_CryptaTool.Presenter;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Clone_CryptaTool
{
    /// <summary>
    /// Логика взаимодействия для Page_RandomNumberGenerator.xaml
    /// </summary>
    public partial class Page_RandomNumberGenerator : Page, IView_RandomPage
    {

        private Presenter_RandomNumbers presenter;
        public Page_RandomNumberGenerator()
        {
            InitializeComponent();
            presenter = new Presenter_RandomNumbers(this);
        }

        public long seed { get => Convert.ToInt64(Start_Number.Text); set => Start_Number.Text = value.ToString(); }
        public long randomNumber { get => 0; set => out_put.Text += value.ToString() + "\n"; }
        public bool arrangment { get => (bool)CheckBox_Arrangment.IsChecked; set => CheckBox_Arrangment.IsChecked = value; }
        public long countNimbers { get => Convert.ToInt64(Count.Text); set => Start_Number.Text = value.ToString(); }
        public long toSecondNumber { get => Convert.ToInt64(TextBox_Max_Value.Text); set => TextBox_Max_Value.Text = value.ToString(); }
        public long fromFirstNumber { get => Convert.ToInt64(TextBox_Min_Value.Text); set => TextBox_Min_Value.Text = value.ToString(); }

        private void  Button_Click(object sender, RoutedEventArgs e)
        {
            out_put.Clear();
            presenter.Next();
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "WriteLines.txt"), true);

            //   outputFile.WriteLine(number.ToString()+ "\n");
            //}
            //outputFile.Close();
        }

        private void CheckBox_Arrangment_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox_Arrangment.IsChecked == true)
                stackPanel_Arrangment.Visibility = Visibility.Visible;
            else
                stackPanel_Arrangment.Visibility = Visibility.Collapsed;
        }
    }
}


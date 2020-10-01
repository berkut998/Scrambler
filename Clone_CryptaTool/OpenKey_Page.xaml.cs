using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using deffie_hellman;
using Vigener;

namespace Clone_CryptaTool
{
    /// <summary>
    /// Логика взаимодействия для OpenKey_Page.xaml
    /// </summary>
    public partial class OpenKey_Page : Page
    {
        OpenKey Alice_Open_key;
        OpenKey Bob_Open_key;
        Cipher_Vigener vigener = new Cipher_Vigener();
        public OpenKey_Page()
        {
            Alice_Open_key = new OpenKey();
            Bob_Open_key = new OpenKey(Alice_Open_key.A, Alice_Open_key.Exp, Alice_Open_key.Main_1);
            Alice_Open_key.fin_key(Bob_Open_key.A);
            InitializeComponent();
            Alice_Key.Content += Alice_Open_key.Fin.ToString();
            Bob_key.Content += Bob_Open_key.Fin.ToString();
        }

        public static string EncodeDecrypt(string str, BigInteger secretKey)
        {
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        public static char TopSecret(char character, BigInteger secretKey)
        {

            character = (char)(character * secretKey); //Производим XOR операцию
            return character;
        }

        public static string DecodeDecrypt(string str, BigInteger secretKey)
        {
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)  //выбираем каждый элемент из массива символов нашей строки
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        private void Bob_Message_button_Click(object sender, RoutedEventArgs e)
        {
            string st = vigener.Encode(mess_box2.Text, Bob_Open_key.Fin.ToString());
            all_box.Text += "Боб: " + st + "\n";
            Chat1.Text += "Боб: " + vigener.Decode(st, Bob_Open_key.Fin.ToString()) + "\n";
        }

        private void Alice_Message_button_Click(object sender, RoutedEventArgs e)
        {
            string st = vigener.Encode(mess_box1.Text, Alice_Open_key.Fin.ToString());
            all_box.Text += "Алиса: " + st + "\n";
            Chat2.Text += "Алиса: " + vigener.Decode(st, Alice_Open_key.Fin.ToString()) + "\n";
        }
    }
}

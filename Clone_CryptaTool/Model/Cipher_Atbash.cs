using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atbash
{
    class Cipher_Atbash
    {
        static private char[] characters = new char[] {
                                                'а','б','в','г','д','е','ё','ж','з','и','й','к',
                                                'л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш',
                                                'щ','ъ','ы','ь','э','ю','я',
                                                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0','.',','};
        static private int N = characters.Length;

        public string Encode (string Not_encrypted_string)
        {
            string encrypted = "";
            foreach (char element in Not_encrypted_string)
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    if (element == characters[i])
                    {
                        encrypted += characters[N - i - 1];
                        break;
                    }
                }
            }
            return encrypted;
        }

        public string decrypt (string encrypted_string)
        {
            string decrypted ="";
            foreach (char element in encrypted_string)
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    if (element == characters[i])
                    {
                        decrypted += characters[N - i - 1];
                        break;
                    }
                }
            }
            return decrypted;
        }
    }
}

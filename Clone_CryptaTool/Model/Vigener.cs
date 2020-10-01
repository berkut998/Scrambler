using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigener
{
    
        class Cipher_Vigener
    {
            static private char[] characters = new char[] {
                                                'а','б','в','г','д','е','ё','ж','з','и','й','к',
                                                'л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш',
                                                'щ','ъ','ы','ь','э','ю','я',
                                                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0'};
            private int N = characters.Length;

            //зашифровать
            public string Encode(string input, string keyword)
            {
                //  input = input.ToUpper();
                //   keyword = keyword.ToUpper();

                string result = "";

                int keyword_index = 0;

                foreach (char symbol in input)
                {
                    int c = (Array.IndexOf(characters, symbol) +
                        Array.IndexOf(characters, keyword[keyword_index])) % N;

                    result += characters[c];

                    keyword_index++;

                    if ((keyword_index + 1) == keyword.Length)
                        keyword_index = 0;
                }

                return result;
            }
            //расшифровать
            public string Decode(string input, string keyword)
            {
                // input = input.ToUpper();
                // keyword = keyword.ToUpper();

                string result = "";

                int keyword_index = 0;

                foreach (char symbol in input)
                {
                    int p = (Array.IndexOf(characters, symbol) + N -
                        Array.IndexOf(characters, keyword[keyword_index])) % N;

                    result += characters[p];

                    keyword_index++;

                    if ((keyword_index + 1) == keyword.Length)
                        keyword_index = 0;
                }
                return result;
            }
        }
    
}

using System;

namespace Net_Festiel
{
    class Festiel_algoritm
    {
        private const int sizeOfBlock = 128; //в DES размер блока 64 бит, но поскольку в unicode символ в два раза длинее, то увеличим блок тоже в два раза
        private const int sizeOfChar = 16; //размер одного символа (in Unicode 16 bit)

        private const int shiftKey = 2; //сдвиг ключа 

        public const int quantityOfRounds = 16; //количество раундов

        public string[] Blocks; //сами блоки в двоичном формате

        public string StringToRightLength(string input)
        {
            while (((input.Length * sizeOfChar) % sizeOfBlock) != 0)
                input += "#";

            return input;
        }

        public void CutStringIntoBlocks(string input)
        {
            Blocks = new string[(input.Length * sizeOfChar) / sizeOfBlock];

            int lengthOfBlock = input.Length / Blocks.Length;

            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
                Blocks[i] = StringToBinaryFormat(Blocks[i]);
            }
        }

        public void CutBinaryStringIntoBlocks(string input)
        {
            Blocks = new string[input.Length / sizeOfBlock];

            int lengthOfBlock = input.Length / Blocks.Length;

            for (int i = 0; i < Blocks.Length; i++)
                Blocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
        }

        public string StringToBinaryFormat(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                string char_binary = Convert.ToString(input[i], 2);

                while (char_binary.Length < sizeOfChar)
                    char_binary = "0" + char_binary;

                output += char_binary;
            }

            return output;
        }

        public string EncodeDES_One_Round(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (R + XOR(L, f(R, key)));
        }

        public string DecodeDES_One_Round(string input, string key)
        {
            string L = input.Substring(0, input.Length / 2);
            string R = input.Substring(input.Length / 2, input.Length / 2);

            return (XOR(f(L, key), R) + L);
        }

        private string XOR(string s1, string s2)
        {
            string result = "";

            for (int i = 0; i < s1.Length; i++)
            {
                bool a = Convert.ToBoolean(Convert.ToInt32(s1[i].ToString()));
                bool b = Convert.ToBoolean(Convert.ToInt32(s2[i].ToString()));

                if (a ^ b)
                    result += "1";
                else
                    result += "0";
            }
            return result;
        }

        private string f(string s1, string s2)
        {
            return XOR(s1, s2);
        }

        public string KeyToNextRound(string key)
        {
            for (int i = 0; i < shiftKey; i++)
            {
                key = key[key.Length - 1] + key;
                key = key.Remove(key.Length - 1);
            }

            return key;
        }

        public string KeyToPrevRound(string key)
        {
            for (int i = 0; i < shiftKey; i++)
            {
                key = key + key[0];
                key = key.Remove(0, 1);
            }

            return key;
        }

        public string StringFromBinaryToNormalFormat(string input)
        {
            string output = "";

            while (input.Length > 0)
            {
                string char_binary = input.Substring(0, sizeOfChar);
                input = input.Remove(0, sizeOfChar);

                int a = 0;
                int degree = char_binary.Length - 1;

                foreach (char c in char_binary)
                    a += Convert.ToInt32(c.ToString()) * (int)Math.Pow(2, degree--);

                output += ((char)a).ToString();
            }

            return output;
        }



        public string CorrectKeyWord(string input, int lengthKey)
        {
            if (input.Length > lengthKey)
                input = input.Substring(0, lengthKey);
            else
                while (input.Length < lengthKey)
                    input = "0" + input;

            return input;
        }

        public string encodeFestiel(string inputText, ref string key)
        {
            string Mystring = inputText;
            string tmpkey = key;
            Mystring = StringToRightLength(Mystring);
            CutStringIntoBlocks(Mystring);
            tmpkey = CorrectKeyWord(key, Mystring.Length / (2 * Blocks.Length));
            tmpkey = StringToBinaryFormat(tmpkey);
            for (int j = 0; j < Festiel_algoritm.quantityOfRounds; j++)
            {
                for (int i = 0; i < Blocks.Length; i++)
                    Blocks[i] = EncodeDES_One_Round(Blocks[i], tmpkey);
                tmpkey = KeyToNextRound(tmpkey);
            }
            tmpkey = KeyToPrevRound(tmpkey);
            tmpkey = StringFromBinaryToNormalFormat(tmpkey);
            string result = "";
            for (int i = 0; i < Blocks.Length; i++)
                result += Blocks[i];
            key = tmpkey;
            return StringFromBinaryToNormalFormat(result);

        }

        public string decodeFestiel(string inputText, ref string key)
        {
            string s = inputText;
            string tmpkey = StringToBinaryFormat(key);
            s = StringToBinaryFormat(inputText);
            CutBinaryStringIntoBlocks(s);
            for (int j = 0; j < Festiel_algoritm.quantityOfRounds; j++)
            {
                for (int i = 0; i < Blocks.Length; i++)
                    Blocks[i] = DecodeDES_One_Round(Blocks[i], tmpkey);
                tmpkey = KeyToPrevRound(tmpkey);
            }
            tmpkey = KeyToNextRound(tmpkey);
            key = StringFromBinaryToNormalFormat(tmpkey);
            string result = "";
            for (int i = 0; i < Blocks.Length; i++)
                result += Blocks[i];
            return StringFromBinaryToNormalFormat(result);


        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Vigener;
using deffie_hellman;
using Net_Festiel;
using Atbash;
using RandomNumberGenerator;

namespace Clone_CryptaTool
{
    class Model
    {
        public string beforeText { get; set; }
        public string afterText { get; set; }
        public string keyWord { get; set; }
        public long randomNamber { get; set; }
        public void encodeToAtabash()
        {
            Cipher_Atbash cipher_Atbash = new Cipher_Atbash();
            afterText = cipher_Atbash.Encode(beforeText);
        }

        public void decodeFromAtabash()
        {
            Cipher_Atbash cipher_Atbash = new Cipher_Atbash();
            afterText = cipher_Atbash.decrypt(beforeText);
        }

        public void encodeToVigener()
        {
            Cipher_Vigener cipher_Vigener = new Cipher_Vigener();
            afterText = cipher_Vigener.Encode(beforeText,keyWord);
        }


        public void decodeFromVigener()
        {
            Cipher_Vigener cipher_Vigener = new Cipher_Vigener();
            afterText = cipher_Vigener.Decode(beforeText, keyWord);
        }

        public void encodeToUseOpenKey()
        {
            OpenKey openKey = new OpenKey();
        }
        public void decodeFromUseOpenKey()
        {
            OpenKey openKey = new OpenKey();
        }
        public void encodeToFestiel()
        {
            Festiel_algoritm festiel = new Festiel_algoritm();
            string key = keyWord;
            afterText = festiel.encodeFestiel(beforeText,ref key);
            keyWord = key;
        }
        public void decodeFromFestiel()
        {
            Festiel_algoritm festiel = new Festiel_algoritm();
            string key = keyWord;
            afterText = festiel.decodeFestiel(beforeText,ref key);
            keyWord = key;
        }

        public void randomNumber ()
        {
            RandomGenerator random = new RandomGenerator();
        }



    }
}

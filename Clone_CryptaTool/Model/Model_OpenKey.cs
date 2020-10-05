using deffie_hellman;
using Vigener;

namespace Clone_CryptaTool.Model
{
    class Model_OpenKey
    {
        //user1 =alice user2= bob
        public string messageToUser1 { get; set; }
        public string messageToUser2 { get; set; }
        public string openKeyUser1 { get; set; }
        public string openKeyUser2 { get; set; }
        public string encryptedMessageFromAlice { get; set; }
        public string encryptedMessageFromBob { get; set; }
        private Cipher_Vigener vigener = new Cipher_Vigener();
        public Model_OpenKey()
        {
            createPrivateKey();
        }
        private void createPrivateKey()
        {
            OpenKey keyForAlice = new OpenKey();
            OpenKey keyForBob = new OpenKey(keyForAlice.A, keyForAlice.Exp, keyForAlice.Main_1);
            keyForAlice.fin_key(keyForBob.A);
            openKeyUser1 = keyForAlice.Fin.ToString();
            openKeyUser2 = keyForBob.Fin.ToString();
        }
        public void encryptMessageUseKeyAlice(string message)
        {
            encryptedMessageFromAlice = vigener.Encode(message, openKeyUser1);
        }
        public void encryptMessageUseKeyBob(string message)
        {
            encryptedMessageFromBob = vigener.Encode(message, openKeyUser2);
        }
        public void decryptMessageFromBob()
        {
            messageToUser1 = vigener.Decode(encryptedMessageFromBob, openKeyUser1);
        }
        public void decryptMessageFromAlice()
        {
            messageToUser2 = vigener.Decode(encryptedMessageFromAlice, openKeyUser2);
        }


    }
}

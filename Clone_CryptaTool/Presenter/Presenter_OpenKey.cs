using Clone_CryptaTool.Interface;
using Clone_CryptaTool.Model;

namespace Clone_CryptaTool.Presenter
{
    class Presenter_OpenKey
    {
        private Model_OpenKey model_openkey;
        private IView_OpenKey_Page view_openkey;

        public Presenter_OpenKey(IView_OpenKey_Page view)
        {
            this.view_openkey = view;
            model_openkey = new Model_OpenKey();
            this.view_openkey.openKeyUser1 = model_openkey.openKeyUser1;
            this.view_openkey.openKeyUser2 = model_openkey.openKeyUser2;
        }

        public void SendMessageFromAllice()
        {
            model_openkey.encryptMessageUseKeyAlice(view_openkey.messageFromUser1);
            view_openkey.messageFromUser1 = "";
            view_openkey.encryptedMessage_FromAlice = model_openkey.encryptedMessageFromAlice;
            model_openkey.decryptMessageFromAlice();
            view_openkey.messageToUser2 = model_openkey.messageToUser2;
        }

        public void SendMessageFromBob()
        {
            model_openkey.encryptMessageUseKeyBob(view_openkey.messageFromUser2);
            view_openkey.messageFromUser2 = "";
            view_openkey.encryptedMessage_FromBob = model_openkey.encryptedMessageFromBob;
            model_openkey.decryptMessageFromBob();
            view_openkey.messageToUser1 = model_openkey.messageToUser1;
        }
    }

}

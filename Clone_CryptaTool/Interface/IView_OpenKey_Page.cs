namespace Clone_CryptaTool.Interface
{
    interface IView_OpenKey_Page
    {
        public string messageToUser1 { get; set; }  //chat 1
        public string messageToUser2 { get; set; } //chat 2
        public string messageFromUser1 { get; set; } //box with message 1
        public string messageFromUser2 { get; set; } //box with message 2
        public string openKeyUser1 { get; set; }
        public string openKeyUser2 { get; set; }
        public string encryptedMessage_FromAlice { get; set; }
        public string encryptedMessage_FromBob { get; set; }

    }
}

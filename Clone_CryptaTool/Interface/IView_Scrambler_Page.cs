namespace Clone_CryptaTool.Interface
{
    interface IView_Scrambler_Page
    {
        string beforeText { get; set; }
        string afterText { get; set; }
        string keyWord { get; set; }
        byte currentOperation { get; }

    }
}

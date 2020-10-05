namespace Clone_CryptaTool.Interface
{
    interface IView_RandomPage
    {
        public long seed { get; set; }
        public long randomNumber { get; set; }
        public bool arrangment { get; set; }
        public long fromFirstNumber { get; set; }
        public long toSecondNumber { get; set; }
        public long countNimbers { get; set; }
    }
}

using System;
using System.Numerics;

namespace deffie_hellman
{
    class OpenKey
    {
        private const Int32 begin_diapason = 5;
        private const Int32 end_diapason = 10;
        public BigInteger Main_1 { get; }
        public BigInteger Exp { get; }
        private BigInteger priv_1;
        public BigInteger Fin;
        public BigInteger A { get; }
        public OpenKey()
        {
            Random random = new Random();
            Exp = getRandom(random.Next(begin_diapason, end_diapason));
            Main_1 = getRandom(random.Next(begin_diapason, end_diapason));
            priv_1 = getRandom(new Random().Next(begin_diapason, end_diapason));
            while (Miller_Rabin(Exp, 10) != true)
            {
                Exp = getRandom(random.Next(begin_diapason, end_diapason));
            }
            while (Miller_Rabin(Main_1, 10) != true && Exp == Main_1)
            {
                Main_1 = getRandom(random.Next(begin_diapason, end_diapason));
            }
            A = BigInteger.ModPow(Main_1, priv_1, Exp);
        }

        public OpenKey(BigInteger a, BigInteger exp, BigInteger main_1)
        {
            Random rnd = new Random();
            BigInteger priv_2 = getRandom(new Random().Next(begin_diapason, end_diapason));
            A = BigInteger.ModPow(main_1, priv_2, exp);
            Exp = exp;
            Main_1 = main_1;
            Fin = BigInteger.ModPow(a, priv_2, exp);
        }

        public BigInteger getRandom(int length)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            return BigInteger.Abs(new BigInteger(data));
        }
        /// <summary>
        /// Searching nearest primery number from Number
        /// </summary>
        /// <param name="Number">Random Number</param>
        /// <param name="Accuracy">Index of accuracy. Example 100 that mean 4^100</param>
        public Boolean Miller_Rabin(BigInteger Number, Int32 Accuracy)
        {

            // если n == 2 или n == 3 - эти числа простые, возвращаем true
            if (Number == 2 || Number == 3)
                return true;

            // если n < 2 или n четное - возвращаем false
            if (Number < 2 || Number % 2 == 0)
                return false;  //цикл на + 1
            BigInteger t = Number - 1;

            int s = 0;

            while (t % 2 == 0) //представим n − 1 в виде (2^s)·t, где t нечётно
            {
                t /= 2;
                s += 1;
            }
            for (int i = 0; i < Accuracy; i++)
            {
                BigInteger a = getRandom(new Random().Next(Number.ToString().Length / 2, Number.ToString().Length));
                BigInteger bigNumber = BigInteger.ModPow(a, t, Number);
                if (bigNumber == 1 || bigNumber == Number - 1)
                {
                    continue;
                }
                else
                {
                    for (int r = 1; r < s; r++)
                    {
                        bigNumber = BigInteger.ModPow(bigNumber, 2, Number);
                        if (bigNumber == 1)
                            return false;  //кароче надо возвращать типа фолс
                        if (bigNumber == Number - 1)
                            break;
                    }
                    return false; //состовное фолс
                }
            }
            return true;//вероятно простое
        }

        public void fin_key(BigInteger B)
        {
            Fin = BigInteger.ModPow(B, priv_1, Exp);
        }


    }
}

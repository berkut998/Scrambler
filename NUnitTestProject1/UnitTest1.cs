using Atbash;
using NUnit.Framework;
using RandomNumberGenerator;


namespace NUnitTestProject1
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            Cipher_Atbash atbash = new Cipher_Atbash();
            string resultEncode = atbash.Encode("��� ��������");
            string resultDecode = atbash.decrypt(resultEncode);
            Assert.AreEqual("��� ��������", resultDecode);
            Assert.AreEqual("�� ��,.��,7�", resultEncode);
        }
        [Test]
        public void testRandomGenerator()
        {
            RandomGenerator random = new RandomGenerator();
            long number1 = random.next(0, 10);
            Assert.Greater(number1, -1);
            Assert.Less(number1, 11);
        }
        [Test]
        public void testRandomGenerator_Seed()
        {
            RandomGenerator random = new RandomGenerator(123456789);
            long number1 = random.next(0, 10);
            Assert.Greater(number1, -1);
            Assert.Less(number1, 11);
        }


    }
}
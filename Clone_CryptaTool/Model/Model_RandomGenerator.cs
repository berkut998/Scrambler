using RandomNumberGenerator;

namespace Clone_CryptaTool.Model
{
    class Model_RandomGenerator
    {
        public long seed { get; set; }
        public long randomNumber { get; set; }
        public bool arrangment { get; set; }
        public long countNumbers { get; set; }

        private RandomGenerator random;

        public Model_RandomGenerator(long seed)
        {
            random = new RandomGenerator(seed);
        }
        public Model_RandomGenerator()
        {
            random = new RandomGenerator();
        }
        public void next()
        {
            randomNumber = random.next();
        }
        public void next(long fromFirst, long toSecond)
        {
            randomNumber = random.next(fromFirst, toSecond);
        }


    }
}

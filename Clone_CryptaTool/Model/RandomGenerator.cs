using System;
using System.Diagnostics;


namespace RandomNumberGenerator
{
    public class RandomGenerator
    {
        private PerformanceCounter memoryCounter;
        private PerformanceCounter CPUCounter;
        private DateTime currentTime;
        private long seed;

        public RandomGenerator()
        {
            memoryCounter = new System.Diagnostics.PerformanceCounter();
            memoryCounter.CategoryName = "Memory";
            memoryCounter.CounterName = "Available MBytes";

            CPUCounter = new System.Diagnostics.PerformanceCounter();
            CPUCounter.CategoryName = "Processor";
            CPUCounter.CounterName = "% Processor Time";
            CPUCounter.InstanceName = "_Total";
        }

        public RandomGenerator(long seed)
        {
            memoryCounter = new System.Diagnostics.PerformanceCounter();
            memoryCounter.CategoryName = "Memory";
            memoryCounter.CounterName = "Available MBytes";
            CPUCounter = new System.Diagnostics.PerformanceCounter();
            CPUCounter.CategoryName = "Processor";
            CPUCounter.CounterName = "% Processor Time";
            CPUCounter.InstanceName = "_Total";
            this.seed = seed;
        }

        public long next()
        {
            long memory = memoryCounter.RawValue;
            long cpu = CPUCounter.RawValue;
            currentTime = DateTime.Now;
            long nextNumber = 0;
            if (seed != 0)
            {
                nextNumber = Math.Abs(memory * cpu * currentTime.Ticks * seed);
            }
            else
            {
                nextNumber = Math.Abs(memory * cpu * currentTime.Ticks);
            }
            return nextNumber;
        }
        public long next(long firtArrangement, long secondArrangment)
        {
            long numberBetween = next() % (secondArrangment - firtArrangement + 1) + firtArrangement;
            return numberBetween;
        }
    }
}

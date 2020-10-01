using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Media.Effects;
using System.Linq.Expressions;

namespace RandomNumberGenerator
{
    class RandomGenerator
    {
        private PerformanceCounter memoryCounter;
        private PerformanceCounter CPUCounter;
        private DateTime cuurentTime = new DateTime();

        private long seed;
        public RandomGenerator ()
        {
            memoryCounter = new System.Diagnostics.PerformanceCounter();
            memoryCounter.CategoryName = "Memory";
            memoryCounter.CounterName = "Available MBytes";

            CPUCounter = new System.Diagnostics.PerformanceCounter();
            CPUCounter.CategoryName = "Processor";
            CPUCounter.CounterName = "% Processor Time";
            CPUCounter.InstanceName = "_Total";
        }

       public  RandomGenerator(long seed)
        {
            this.seed = seed;
        }

        public long next ()
        {
            long nextNumber = 0;
            if (seed == null)
                ;
            else
            {
                long memory = memoryCounter.RawValue;

            }

            return nextNumber;
        }
    }
}

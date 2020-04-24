using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery
{
    public static class NumbersGenerator
    {
        private static Random rnd = new Random();

        public static List<int> GenerateListWithUniqueNumbers(int count, int minValue, int maxValue)
        {
            if (count > maxValue)
                throw new ArgumentException("maxValue must be equel or more than count");

            HashSet<int> temporarySet = new HashSet<int>();

            while (temporarySet.Count < count)
            {
                temporarySet.Add(rnd.Next(minValue, maxValue + 1));
            }
            return temporarySet.ToList<int>();
        }
        public static Queue<int> GenerateQueueWithUniqueNumbers(int count, int minValue, int maxValue)
        {
            if (count > maxValue)
                throw new ArgumentException("maxValue must be equel or greater than count");

            Queue<int> temporaryQueue = new Queue<int>();

            var temporaryList = Enumerable.Range(minValue, maxValue + 1).OrderBy(x => rnd.Next()).Take(count);
            foreach (int item in temporaryList)
            {
                temporaryQueue.Enqueue(item);
            }
            return temporaryQueue;
        }
    }
}

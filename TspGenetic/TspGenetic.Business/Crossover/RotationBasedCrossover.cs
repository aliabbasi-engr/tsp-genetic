using System;
using TspGenetic.Business.Model;

namespace TspGenetic.Business.Crossover
{
    public class RotationBasedCrossover : ICrossover
    {
        public (Individual child1, Individual child2) Crossover(Individual parent1, Individual parent2)
        {
            parent1 = parent1.Clone();
            parent2 = parent2.Clone();

            var child1 = new Individual();
            var child2 = new Individual();
            bool flag = true;

            while (GetFirstAvailableIndex(parent1.Chromosome) != -1)
            {
                var firstIndex = GetFirstAvailableIndex(parent1.Chromosome);
                
                var firstChild = flag ? child1 : child2;
                var secondChild = flag ? child2 : child1;
                flag = !flag;

                var index = firstIndex;
                do
                {
                    firstChild.Chromosome[index] = parent1.Chromosome[index];
                    secondChild.Chromosome[index] = parent2.Chromosome[index];

                    var tempIndex = index;
                    index = Array.IndexOf(parent1.Chromosome, parent2.Chromosome[index]);
                    
                    parent1.Chromosome[tempIndex] = -2;
                    parent2.Chromosome[tempIndex] = -2;

                    if (index == tempIndex)
                        break;

                } while (index != -1);
            }

            return (child1, child2);
        }

        private int GetFirstAvailableIndex(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != -2)
                    return i;
            }
            return -1;
        }
    }
}

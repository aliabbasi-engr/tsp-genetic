using System;
using System.Linq;
using TspGenetic.Business.Model;

namespace TspGenetic.Business.Crossover
{
    public class OrderOneCrossover : ICrossover
    {
        public (Individual child1, Individual child2) Crossover(Individual parent1, Individual parent2)
        {
            parent1 = parent1.Clone();
            parent2 = parent2.Clone();

            (var startIndex, var endIndex) = Helper.GetTwoRandomNumbers(0, parent1.Chromosome.Length, false);

            var child1 = GetChild(parent1, parent2, startIndex, endIndex);
            var child2 = GetChild(parent2, parent1, startIndex, endIndex);

            return (child1, child2);
        }

        private Individual GetChild(Individual parent1, Individual parent2, int startIndex, int endIndex)
        {
            var child = new Individual();

            var length = endIndex - startIndex + 1;
            Array.Copy(parent1.Chromosome, startIndex, child.Chromosome, startIndex, length);

            var childIndex = GetNextIndex(endIndex);
            var parentIndex = GetNextIndex(endIndex);

            while(child.Chromosome.Contains(-1))
            {
                while (child.Chromosome.Contains(parent2.Chromosome[parentIndex]))
                    parentIndex = GetNextIndex(parentIndex);

                child.Chromosome[childIndex] = parent2.Chromosome[parentIndex];
                childIndex = GetNextIndex(childIndex);
                parentIndex = GetNextIndex(parentIndex);
            }

            return child;
        }

        private int GetNextIndex(int index)
        {
            return (index + 1) % Constants.CHROMOSE_LENGHT;
        }
    }
}

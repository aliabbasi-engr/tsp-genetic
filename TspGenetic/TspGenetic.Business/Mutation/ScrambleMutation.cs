using System;
using System.Linq;
using TspGenetic.Business.Model;

namespace TspGenetic.Business.Mutation
{
    public class ScrambleMutation : IMutation
    {
        public Individual Mutate(Individual individual)
        {
            individual = individual.Clone();

            (var firstIndex, var secondIndex) = Helper.GetTwoRandomNumbers(0, individual.Chromosome.Length, true);

            var length = secondIndex - firstIndex + 1;
            var tempArray = new int[length];
            Array.Copy(individual.Chromosome, firstIndex, tempArray, 0, length);
            var tempList = tempArray.ToList();

            for (int i = firstIndex; i <= secondIndex; i++)
            {
                var randomIndex = Helper.GetRandomNumber(0, tempList.Count);
                individual.Chromosome[i] = tempList[randomIndex];
                tempList.RemoveAt(randomIndex);
            }

            return individual;
        }
    }
}

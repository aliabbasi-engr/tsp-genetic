using System;
using TspGenetic.Business.Model;

namespace TspGenetic.Business.Mutation
{
    public class SwapMutation : IMutation
    {
        public Individual Mutate(Individual individual)
        {
            individual = individual.Clone();

            (var firstIndex, var secondIndex) = Helper.GetTwoRandomNumbers(0, individual.Chromosome.Length, true);
            
            var temp = individual.Chromosome[firstIndex];
            individual.Chromosome[firstIndex] = individual.Chromosome[secondIndex];
            individual.Chromosome[secondIndex] = temp;

            return individual;
        }
    }
}

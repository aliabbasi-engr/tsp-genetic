using TspGenetic.Business.Model;

namespace TspGenetic.Business.Mutation
{
    public class InsertionMutation : IMutation
    {
        public Individual Mutate(Individual individual)
        {
            individual = individual.Clone();

            (var firstIndex, var secondIndex) = Helper.GetTwoRandomNumbers(0, individual.Chromosome.Length, true);

            var temp = individual.Chromosome[secondIndex];
            while (secondIndex >= firstIndex + 2)
            {
                individual.Chromosome[secondIndex] = individual.Chromosome[secondIndex - 1];
                secondIndex--;
            }
            individual.Chromosome[secondIndex] = temp;

            return individual;
        }
    }
}

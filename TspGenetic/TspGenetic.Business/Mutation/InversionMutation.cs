using TspGenetic.Business.Model;

namespace TspGenetic.Business.Mutation
{
    public class InversionMutation : IMutation
    {
        public Individual Mutate(Individual individual)
        {
            individual = individual.Clone();

            (var firstIndex, var secondIndex) = Helper.GetTwoRandomNumbers(0, individual.Chromosome.Length, true);

            var midIndex = (secondIndex - firstIndex + 1) / 2 - 1 + firstIndex;

            for (int i = firstIndex; i <= midIndex; i++)
            {
                var j = secondIndex - i + firstIndex;

                var temp = individual.Chromosome[i];
                individual.Chromosome[i] = individual.Chromosome[j];
                individual.Chromosome[j] = temp;
            }

            return individual;
        }
    }
}

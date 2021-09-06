using System.Linq;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.SurvivorSelection
{
    public class AgeBasedSurvivorSelection : ISurvivorSelection
    {
        public Population SelectSuvivors(Population population, int survivorCount)
        {
            population = population.Clone();

            var suvivors = new Population();

            var fittestIndividualInPreviousGeneration = population.GetFittestIndividualInPreviousGenerations();
            suvivors.Individuals.Add(fittestIndividualInPreviousGeneration);
            population.Individuals.Remove(fittestIndividualInPreviousGeneration);

            suvivors.Individuals.AddRange(population.Individuals.OrderByDescending(x => x.Generation).Take(survivorCount - 1));

            return suvivors;
        }
    }
}

using System.Linq;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.SurvivorSelection
{
    public class FitnessBasedSurvivorSelection : ISurvivorSelection
    {
        public Population SelectSuvivors(Population population, int survivorCount)
        {
            population = population.Clone();

            var suvivors = new Population();

            var fittestIndividualInPreviousGeneration = population.GetFittestIndividualInPreviousGenerations();
            suvivors.Individuals.Add(fittestIndividualInPreviousGeneration);
            population.Individuals.Remove(fittestIndividualInPreviousGeneration);

            suvivors.Individuals.AddRange(population.Individuals.OrderBy(x => x.GetFitness()).Take(survivorCount - 1));

            return suvivors;
        }
    }
}

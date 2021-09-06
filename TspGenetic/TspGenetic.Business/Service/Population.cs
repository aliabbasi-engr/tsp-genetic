using System.Collections.Generic;
using System.Linq;
using TspGenetic.Business.Model;

namespace TspGenetic.Business.Service
{
    public class Population
    {
        public List<Individual> Individuals { get; set; }

        public Population()
        {
            Individuals = new List<Individual>();
        }

        public Population(List<Individual> individuals)
        {
            Individuals = individuals;
        }
        
        public void Initialize(int populationSize)
        {
            Individuals.Clear();
            for (int i = 0; i < populationSize; i++)
            {
                var randomIndividual = GetRandomIndividual();
                Individuals.Add(randomIndividual);
            }
        }
        
        public Population Clone()
        {
            var individuals = new List<Individual>(this.Individuals);

            return new Population(individuals);
        }

        public double GetFitnessAverage()
        {
            return Individuals.Average(x => x.GetFitness());
        }

        public Individual GetFittestIndividual()
        {
            var min = Individuals.Min(x => x.GetFitness());
            return Individuals.First(x => x.GetFitness() == min);
        }

        public Individual GetFittestIndividualInPreviousGenerations()
        {
            var maxGeneration = Individuals.Select(x => x.Generation).Max();
            return Individuals.Where(x => x.Generation != maxGeneration).OrderBy(x => x.GetFitness()).First();
        }

        private Individual GetRandomIndividual()
        {
            var individual = new Individual
            {
                Chromosome = GetRandomChromosome(),
                Generation = 0
            };

            return individual;
        }

        private int[] GetRandomChromosome()
        {
            var alleles = Enumerable.Range(0, Constants.CHROMOSE_LENGHT).ToList();
            var chromosome = new int[Constants.CHROMOSE_LENGHT];

            var index = 0;
            while (alleles.Any())
            {
                var randomIndex = Helper.GetRandomNumber(0, alleles.Count());
                chromosome[index++] = alleles.ElementAt(randomIndex);
                alleles.RemoveAt(randomIndex);
            }

            return chromosome;
        }
    }
}

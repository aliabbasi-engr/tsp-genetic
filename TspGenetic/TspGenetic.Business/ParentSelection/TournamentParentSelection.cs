using System.Collections.Generic;
using System.Linq;
using TspGenetic.Business.Model;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.ParentSelection
{
    public class TournamentParentSelection : IParentSelection
    {
        private readonly int _k;

        public TournamentParentSelection(int k)
        {
            _k = k;
        }

        public (Individual parent1, Individual parent2) SelectParents(Population population)
        {
            population = population.Clone();

            var parent1 = SelectParent(population);
            
            population.Individuals.Remove(parent1);
            var parent2 = SelectParent(population);
            
            return (parent1, parent2);
        }

        private Individual SelectParent(Population population)
        {
            population = population.Clone();

            var selectedInidividuals = new List<Individual>();

            for (int i = 0; i < _k; i++)
            {
                var randomIndex = Helper.GetRandomNumber(0, population.Individuals.Count);
                selectedInidividuals.Add(population.Individuals[randomIndex]);
                population.Individuals.RemoveAt(randomIndex);
            }

            var minFitness = selectedInidividuals.Min(x => x.GetFitness());

            return selectedInidividuals.First(x => x.GetFitness() == minFitness);
        }
    }
}

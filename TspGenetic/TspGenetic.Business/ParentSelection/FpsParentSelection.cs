using TspGenetic.Business.Model;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.ParentSelection
{
    public class FpsParentSelection : RouletteWheelParentSelection, IParentSelection
    {
        public (Individual parent1, Individual parent2) SelectParents(Population population)
        {
            var weightedIndividual = GetFitnessBasedWeightedIndividuals(population);
            var triples = GetTriples(weightedIndividual);

            var random1 = Helper.GetRandomNumber();
            var parent1 = SelectParent(triples, random1);

            var random2 = Helper.GetRandomNumber();
            var parent2 = SelectParent(triples, random2);

            return (parent1, parent2);
        }
    }
}

using TspGenetic.Business.Model;

namespace TspGenetic.Business.Crossover
{
    public interface ICrossover
    {
        (Individual child1, Individual child2) Crossover(Individual parent1, Individual parent2);
    }
}

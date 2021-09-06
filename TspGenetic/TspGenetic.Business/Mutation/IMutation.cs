using TspGenetic.Business.Model;

namespace TspGenetic.Business.Mutation
{
    public interface IMutation
    {
        Individual Mutate(Individual individual);
    }
}

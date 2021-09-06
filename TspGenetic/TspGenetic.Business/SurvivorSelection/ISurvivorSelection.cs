using TspGenetic.Business.Service;

namespace TspGenetic.Business.SurvivorSelection
{
    public interface ISurvivorSelection
    {
        Population SelectSuvivors(Population population, int survivorCount);
    }
}

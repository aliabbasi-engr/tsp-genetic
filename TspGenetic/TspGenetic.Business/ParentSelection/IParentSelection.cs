using TspGenetic.Business.Model;
using TspGenetic.Business.Service;

namespace TspGenetic.Business.ParentSelection
{
    public interface IParentSelection
    {
        (Individual parent1, Individual parent2) SelectParents(Population population);
    }
}

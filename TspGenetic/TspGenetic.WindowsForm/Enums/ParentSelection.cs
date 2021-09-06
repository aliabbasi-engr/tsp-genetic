using System.ComponentModel;

namespace TspGenetic.WindowsForm.Enums
{
    public enum ParentSelection
    {
        [Description("Roulette Wheel")]
        RouletteWheel,

        [Description("Rank Based")]
        RankBased,

        [Description("Stochastic")]
        Stochastic,

        [Description("Tournament")]
        Tournament
    }
}

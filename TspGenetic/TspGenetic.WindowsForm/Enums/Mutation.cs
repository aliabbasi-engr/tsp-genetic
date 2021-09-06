using System.ComponentModel;

namespace TspGenetic.WindowsForm.Enums
{
    public enum Mutation
    {
        [Description("Insersion")]
        Insersion,

        [Description("Inversion")]
        Inversion,

        [Description("Scramble")]
        Scramble,

        [Description("Swap")]
        Swap
    }
}

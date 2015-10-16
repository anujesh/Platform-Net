using System.ComponentModel;

namespace Platform.Core.Enums
{
    public enum UserMode
    {
        [Description("Unknown")]
        Unknown = 0,

        [Description("User")]
        User = 1,

        [Description("Admin")]
        Admin = 2,

        [Description("Superman")]
        Superman = 3,

        [Description("System")]
        System = 4
    }
}

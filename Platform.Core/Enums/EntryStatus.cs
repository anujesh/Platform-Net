using System.ComponentModel;

namespace Platform.Core.Enums
{
    public enum EntryStatus
    {
        [Description("Fresh")]
        Fresh = 0,

        [Description("Submitted")]
        Submitted = 1,

        [Description("Approved")]
        Approved = 2,

        [Description("Declined")] // submit again
        Declined = 3,

        [Description("Rejected")] // no way
        Rejected = 4,

        [Description("Published")]
        Published = 5,

        [Description("Deleted")]
        Deleted = 6,

        [Description("Removed")]
        Removed = 7,

        [Description("Archived")]
        Archived = 8,

        [Description("Edited")]
        Edited = 9
    }
}

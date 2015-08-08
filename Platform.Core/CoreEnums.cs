using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core
{
    using System.Reflection;
    using System.ComponentModel;

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

    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }


    public interface SystemListing<T>
    {
        List<T> GetApprovedList();

        List<T> GetRemovedList();

        List<T> GetOtherList();
    }

    public interface UserListing<T>
    {
        List<T> GetFreshList();

        List<T> GetPublishedList();

        List<T> GetRejectedList();

        List<T> GetOtherList();
    }

    public interface AdminListing<T>
    {
        List<T> GetSubmittedList();

        List<T> GetDeletedList();
    }

    public class BaseRepository2<T> where T : class
    {
        public List<T> GetPublishedList()
        {
            return new List<T>();
        }
    }

    /*
    ALL_ENTRIES
    USER_ENTRIES
    ADMIN_ENTRIES
    SYSTEM_ENTRIES
    SUPERMAN_ENTRIES
    */

    public static class ActionChecker
    {
        public static bool IsUpdatableForUser(int entityUserId, int currentUserId)
        {
            return false;
        }

        public static bool IsRequestedActionValid(UserMode curUserMode, EntryStatus curStatus, EntryStatus reqStatus)
        {
            IEnumerable<EntryStatus> outList = GetPossibleActions(curUserMode, curStatus);
            return outList.Any(a => (EntryStatus)a == reqStatus);
        }

        public static IEnumerable<EntryStatus> GetPossibleActions(UserMode curUserMode, EntryStatus curStatus)
        {
            List<EntryStatus> outList = new List<EntryStatus>();

            if (curUserMode == UserMode.User)
            {
                switch (curStatus)
                {
                    case EntryStatus.Fresh:
                        outList.Add(EntryStatus.Submitted);
                        outList.Add(EntryStatus.Deleted);
                        break;
                    case EntryStatus.Rejected:
                        outList.Add(EntryStatus.Deleted);
                        break;
                    case EntryStatus.Published:
                        outList.Add(EntryStatus.Deleted);
                        break;
                }
            }
            else if (curUserMode==UserMode.Admin)
            {
                switch (curStatus)
                {
                    case EntryStatus.Submitted:
                        outList.Add(EntryStatus.Approved);
                        outList.Add(EntryStatus.Rejected);
                        break;
                    case EntryStatus.Deleted:
                        outList.Add(EntryStatus.Removed);
                        break;
                }
            }
            else if (curUserMode==UserMode.Superman)
            {
                switch (curStatus)
                {
                    case EntryStatus.Fresh:
                        outList.Add(EntryStatus.Rejected);
                        break;
                    case EntryStatus.Archived:
                        outList.Add(EntryStatus.Fresh);
                        break;
                }
            }

            return outList;
        }
    }
}


/*
 * 
 Maintainable
 * Histroryable
 * Mapable
 * Adminiable
 * Versionable

 * 
 * 
 * 
 * 
 * 
 A Answers
 * B Blog
 * C creations
 * D Directory
 * E Events
 * F Foods
 * G Groups
 * 
 * 
 */

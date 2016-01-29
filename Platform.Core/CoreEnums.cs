using System.Collections.Generic;
using System.Linq;

namespace Platform.Core
{
    using Enums;

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

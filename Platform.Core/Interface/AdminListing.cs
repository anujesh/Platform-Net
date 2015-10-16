using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface AdminListing<T>
    {
        List<T> GetSubmittedList();

        List<T> GetDeletedList();
    }
}

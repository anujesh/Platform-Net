using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface IAdminListing<T>
    {
        List<T> GetSubmittedList();

        List<T> GetDeletedList();
    }
}

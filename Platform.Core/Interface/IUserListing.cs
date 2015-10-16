using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface IUserListing<T>
    {
        List<T> GetFreshList();

        List<T> GetPublishedList();

        List<T> GetRejectedList();

        List<T> GetOtherList();
    }
}

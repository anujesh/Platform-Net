using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface ISystemListing<T>
    {
        List<T> GetApprovedList();

        List<T> GetRemovedList();

        List<T> GetOtherList();
    }
}

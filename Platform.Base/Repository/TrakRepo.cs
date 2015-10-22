using System.Linq;
using Dapper;
using Platform.Core;

namespace Platform.Base.Repository
{

    public interface ITrakRepo
    {

    }

    public class TrakRepo<T> : CoreRepo<T>, ITrakRepo where T : TrakModel
    {

    }
}

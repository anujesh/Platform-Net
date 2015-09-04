namespace Platform.Core.Request
{
    public interface IRequestProvider
    {
        int GetUserId();
        RequestInfo GetRequestInfo();
    }
}

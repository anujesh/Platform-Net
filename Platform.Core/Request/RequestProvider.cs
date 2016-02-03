namespace Platform.Core.Request
{
    public class RequestProvider : IRequestProvider
    {
        private RequestInfo requestInfo;

        public RequestProvider()
        {
            requestInfo = new RequestInfo();
        }

        public RequestInfo GetRequestInfo()
        {
            return requestInfo;
        }

        public int GetUserId()
        {
            return requestInfo.UserId;
        }
    }
}

using System;

namespace Platform.Id
{
    public class UserToDo
    {
        public int UserId { get; set; }

        public UserToDoType Type { get; set; }

        public string Message { get; set; }
    }

    public enum UserToDoType
    {
        ChangeDisplayName,

        ChangeUserName,

        ChangePassword,

        AgreeTandC,

        UploadProfileImage
    }

    public enum UserToDoBlockType
    {
        Strict,

        Suggested
    }


    public class ExternalTokens
    {
        public int RefId { get; set; }

        //80
        public string Token { get; set; }

        public TokenActions TokenAction { get; set; }

        public DateTime ExpireDate { get; set; }

        public int UserId { get; set; }


    }

    public enum TokenCheckResponse
    {
        Active,

        NotFound,

        Expired,

        InActive
    }

    public interface ITokenService
    {
        ExternalTokens GetExternalToken(string emailGuid, out TokenCheckResponse tokenCheckResponse);
    }

    public class TokenService : ITokenService
    {
        public ExternalTokens GetExternalToken(string emailGuid, out TokenCheckResponse tokenCheckResponse)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITokenRepository
    {

    }

    public class TokenRepository : ITokenRepository
    {

    }

    public enum TokenActions
    {
        ValidateEmail
    }
}

//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace Platform.Id
//{
//    public class CustomUserValidator<TUser> : IIdentityValidator<TUser>
//        where TUser : class, Microsoft.AspNet.Identity.IUser
//    {
//        private static readonly Regex EmailRegex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//        private readonly UserManager<TUser> _manager;

//        public CustomUserValidator()
//        {
//        }

//        public CustomUserValidator(UserManager<TUser> manager)
//        {
//            _manager = manager;
//        }

//        public async Task<IdentityResult> ValidateAsync(TUser item)
//        {
//            var errors = new List<string>();
//            if (!EmailRegex.IsMatch(itemUserName))
//                errors.Add("Enter a valid email address.");

//            if (_manager != null)
//            {
//                var otherAccount = await _manager.FindByNameAsync(item.UserName);
//                if (otherAccount != null && otherAccount.Id != item.Id)
//                    errors.Add("Select a different email address. An account has already been created with this email address.");
//            }

//            return errors.Any()
//                ? IdentityResult.Failed(errors.ToArray())
//                : IdentityResult.Success;
//        }
//    }
//}

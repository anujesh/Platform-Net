//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Platform.Id
//{
//    public static class IdentityExtensions
//    {
//        public static async Task<ApplicationUser> FindByNameOrEmailAsync
//            (this UserManager<ApplicationUser> userManager, string usernameOrEmail, string password)
//        {
//            var username = usernameOrEmail;
//            if (usernameOrEmail.Contains("@"))
//            {
//                var userForEmail = await userManager.FindByEmailAsync(usernameOrEmail);
//                if (userForEmail != null)
//                {
//                    username = userForEmail.UserName;
//                }
//            }
//            return await userManager.FindAsync(username, password);
//        }


//    }
//}

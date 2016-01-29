////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;

////namespace Platform.Id.MySQL
////{
////    public class CustomUserRole : IdentityUserRole<int> { }
////    public class CustomUserClaim : IdentityUserClaim<int> { }
////    public class CustomUserLogin : IdentityUserLogin<int> { }

////    public class CustomRole : IdentityRole<int, CustomUserRole>
////    {
////        public CustomRole() { }
////        public CustomRole(string name) { Name = name; }
////    }

////    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
////        CustomUserLogin, CustomUserRole, CustomUserClaim>
////    {
////        public CustomUserStore(ApplicationDbContext context)
////            : base(context)
////        {
////        }
////    }

////    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
////    {
////        public CustomRoleStore(ApplicationDbContext context)
////            : base(context)
////        {
////        }
////    } 
////}


//// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

////public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>

//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Platform.Id { 
//public class ApplicationUser : IdentityUser
//{
//    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
//    {
//        // Note the authenticationType must match the one defined in
//        // CookieAuthenticationOptions.AuthenticationType 
//        var userIdentity = await manager.CreateIdentityAsync(
//            this, DefaultAuthenticationTypes.ApplicationCookie);
//        // Add custom user claims here 
//        return userIdentity;
//    }
//}

//public class ApplicationDbContext : MySQLDatabase
//{
//    public ApplicationDbContext(string connectionName)
//        : base(connectionName)
//    {
//    }

//    public static ApplicationDbContext Create()
//    {
//        return new ApplicationDbContext("MySqlDB");
//    }
//}
//}





////http://www.asp.net/identity/overview/extensibility/change-primary-key-for-users-in-aspnet-identity

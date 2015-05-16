

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Platform.Core;

namespace Platform.Base.Basic
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public DateTime StartDate { get; set; }
        public int Activity { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public string ProfileImage { get; set; }
        public string ShowName { get; set; }
        public int Gender { get; set; }
        public DOB dob { get; set; }
        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
        public string IpAddress { get; set; }
    }

    // List

    public class CoreUserList
    {
        public CoreUserList()
        {
            page = new Paging();
        }

        public List<User> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpCoreUser : Response
    {
        public User data { get; set; }
    }

    public class rpCoreUserList : Response
    {
        public CoreUserList data { get; set; }
    }

}

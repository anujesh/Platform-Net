

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Platform.Core;

namespace Platform.Base.Basic
{
    public enum CoreGender
    {
        Male = 1,
        Female = 0,
    }

    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public DateTime StartDate { get; set; }
        public int Activity { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public string ProfileImage { get; set; }
        public string ShowName { get; set; }
        public CoreGender Gender { get; set; }
        public DOB Dob { get; set; }
        public string IpAddress { get; set; }
    }

    // List

    public class UserList
    {
        public UserList()
        {
            page = new Paging();
        }

        public List<User> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpUser : Response
    {
        public User data { get; set; }
    }

    public class rpUserList : Response
    {
        public UserList data { get; set; }
    }

}

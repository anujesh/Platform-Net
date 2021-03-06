﻿using System;

namespace Platform.Core.Basic
{
    //ula_mem_bas_user_master
    //Id,Email,UserName,Password,RememberToken,Activity,Points,Rank,ProfileImage,Gender,DofB,MofB,YofB,LastIp,LoginCount,LastLoginAt,UpdatedAt,CreatedAt,UpdatedBy,CreatedBy,Active,Locked

    public enum CoreGender
    {
        Female = 0,
        Male = 1,
    }

    public class User
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime StartDate { get; set; }
        public int Activity { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public string ProfileImage { get; set; }
        public string ShowName { get; set; }
        public CoreGender Gender { get; set; }
        public DOB Dob { get; set; }
        public string LastIp { get; set; }
        public string LoginCount { get; set; }
        public string LastLoginAt { get; set; }
        public string Active { get; set; }
        public string Locked { get; set; }
    }

    // List

    public class Users : CoreList<User>
    {
    }

    // Response

    public class rpUser : ResponseItem<User>
    {
    }

    public class rpUsers : ResponseItem<Users>
    {
    }

}

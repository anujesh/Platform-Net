using Microsoft.AspNet.Identity;
using System;

namespace Platform.Id
{
    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IRole interface 
    /// </summary>
    public class IdentityRole : IRole
    {

        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityRole(string name) : this()
        {
            Name = name;
        }

        public IdentityRole(string name, string id)
        {
            Name = name;
            Id = id;
        }

        /// <summary>
        /// Role ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; }
    }
}

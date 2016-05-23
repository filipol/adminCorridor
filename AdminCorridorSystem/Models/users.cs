using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCorridorSystem.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Grant_type { get; set; }
        public int uId { get; set; }
    }
}
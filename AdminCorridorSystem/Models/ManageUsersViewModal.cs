using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCorridorSystem.Models
{
    public class ManageUsersViewModal
    {
        public List<Users> ManageUser { get; set; }

        public ManageUsersViewModal()
        {
            ManageUser = new List<Users>();
        }
    }
}
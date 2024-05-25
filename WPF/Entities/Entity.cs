using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Entities;

namespace WPF.Entity
{
    public class Entity
    {
        public List<Users> Users { get; set; }
        public List<Admins> Admins { get; set; }
        public List<Services> Services { get; set; }
        public List<Request> Requests { get; set; }

        public Entity()
        {
            Users = new List<Users>();
            Admins = new List<Entities.Admins>();
            Services = new List<Entities.Services>();
            Requests = new List<Request>();
        }

        public Entity(List<Users> users, List<Entities.Admins> admins, List<Services> services, List<Request> requests)
        {
            Users = users;
            Admins = admins;
            Services = services;
            Requests = requests;
        }
    }
}

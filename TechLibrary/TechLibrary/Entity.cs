namespace TechLibrary
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
            Admins = new List<Admins>();
            Services = new List<Services>();
            Requests = new List<Request>();
        }

        public Entity(List<Users> users, List<Admins> admins, List<Services> services, List<Request> requests)
        {
            Users = users;
            Admins = admins;
            Services = services;
            Requests = requests;
        }
    }
}

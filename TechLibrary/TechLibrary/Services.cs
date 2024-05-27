namespace TechLibrary
{
    public class Services
    {
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public Services(string name, string description, int cost  ) 
        {
            ServiceName = name;
            Description = description;
            Cost = cost;
        }
    }
}

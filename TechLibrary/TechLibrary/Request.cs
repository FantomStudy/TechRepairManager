namespace TechLibrary
{
    public class Request
    {
        public string Client{ get; set; }
        public string Comment { get; set; }
        public string TypeOfService { get; set; }
        public bool Status { get; set; }
        public Request(string client, string comment, string typeOfService, bool status)
        {
            Client = client;
            TypeOfService = typeOfService;
            Comment = comment;
            Status = status;
        }
    }
}

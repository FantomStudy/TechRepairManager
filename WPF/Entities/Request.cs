using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Entities
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
            TypeOfService = comment;
            Comment = typeOfService;
            Status = status;
        }
    }
}

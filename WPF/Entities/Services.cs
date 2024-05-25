using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Entities
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

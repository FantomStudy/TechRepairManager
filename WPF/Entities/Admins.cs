using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Entities
{
    public class Admins
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admins(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}

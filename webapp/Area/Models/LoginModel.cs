using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp.Area.Models
{
    public class LoginModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }

        public bool admin { get; set; }
    }
}
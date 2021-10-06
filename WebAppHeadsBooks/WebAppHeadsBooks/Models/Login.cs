using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppHeadsBooks.Models
{
    public class Login
    {
        public String usuario {  get; set;}
        public String password { get; set; }
        public Int32 remember { get; set; }

    }
}
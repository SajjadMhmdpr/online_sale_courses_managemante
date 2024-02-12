using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Model
{
    public class User : IdentityUser 
    {
        public string name{ get; set; }
        public string family { get; set; }
    }
}

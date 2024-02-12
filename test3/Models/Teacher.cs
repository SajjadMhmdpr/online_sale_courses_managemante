using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string email { get; set; }
        public IFormFile pic { get; set; }
        public bool jensyat { get; set; } //true man , false woman

    }
}

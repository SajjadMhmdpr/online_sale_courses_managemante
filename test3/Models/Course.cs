using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3.Models
{
    public class Course
    { 
       public int id { get; set; }
        public string title { get; set; }
        public float totalTime { get; set; }
        public string descript { get; set; }
        public IFormFile videoIntro { get; set; }
        public IFormFile banner { get; set; }
        public float price { get; set; }
        public List<int> teachers { get; set; } 

    }
}

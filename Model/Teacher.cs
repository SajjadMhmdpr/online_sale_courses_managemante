using System;
using System.Collections.Generic;

namespace Model
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string email { get; set; }
        public string pic { get; set; }
        public bool jensyat { get; set; } //true man , false woman
        public List<Teacher_corse> courses { get; set; } = new List<Teacher_corse>();
        //public List<Course> courses { get; set; } = new List<Course>();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Course
    {
        public int id { get; set; }
        public string title { get; set; }
        public float totalTime { get; set; }
        public string descript { get; set; }
        public string videoIntro { get; set; }
        public string banner { get; set; }
        public float price { get; set; }
        public List<Teacher_corse> teachers { get; set; } = new List<Teacher_corse>();
        //public List<Teacher> teachers { get; set; } = new List<Teacher>();
    }

    public class Teacher_corse
    {
        public int id { get; set; }
        public Teacher teacher { get; set; }
        public Course course { get; set; }
    }
}

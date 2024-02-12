using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using data_access.Migrations;

namespace data_access
{
    public class dlCourse
    {

        public void create(Course c, List<int> ids)
        {
            DB db = new DB();

            List<Teacher_corse> tcl = new List<Teacher_corse>();

            foreach (var item in ids)
            {
                Teacher_corse tc = new Teacher_corse();
                var q = db.Teachers.Where(s => s.id == item);
                tc.teacher = q.Single();
                tc.course = c;
                tcl.Add(tc);
            }

            //c.teachers.AddRange((IEnumerable<Teacher_corse>)t);

            c.teachers.AddRange(tcl);

            db.Courses.Add(c);

            db.SaveChanges();
        }

        public List<Course> readAll()
        {
            DB db = new DB();
            return db.Courses.ToList();
        }

        public List<Course> search(string s)
        {
            DB db = new DB();

            if (s == null)
                return db.Courses.ToList();

            float n = 0;
            _ = float.TryParse(s, out n);

            
            var q = from i in db.Courses
                    where i.title.Contains(s) || i.descript.Contains(s)  || i.price ==  n
                    select i;

            return q.ToList();
        }
        public Course search(int id)
        {
            DB db = new DB();


            //var q = from i in db.Courses.Include(s=>s.teachers).ThenInclude(s=>s.teacher)
            //        where i.id==id
            //        select i;
            var q = from i in db.Courses.Include("teachers.teacher")
                    where i.id == id
                    select i;
            var y = 5;

            Course c = q.Single();

            return c;
        }

        public List<Course> search(List<int> ids)
        {
            DB db = new DB();
            var q = db.Courses.Where(s => ids.Contains(s.id));
            return q.ToList();
        }

        public void update(Course c, List<int> ids)
        {
            DB db = new DB();
            var q = from i in db.Courses where i.id == c.id select i;
            Course cc = q.Single();

            cc.title = c.title;
            cc.descript = c.descript;
            cc.videoIntro = c.videoIntro;
            cc.totalTime = c.totalTime;
            cc.price = c.price;
            cc.banner = c.banner;

            
            var qqq = from i in db.TeacherCourses where i.course.id == c.id select i;
            db.TeacherCourses.RemoveRange(qqq.ToList());


            if (ids != null && ids.Count > 0)
            {
                foreach (var item in ids)
                {
                    Teacher_corse tc = new Teacher_corse();
                    var qq = db.Teachers.Where(s => s.id == item);
                    tc.teacher = qq.Single();
                    tc.course = c;
                    cc.teachers.Add(tc);
                }
            }
            

            db.SaveChanges();

        }
    }
}

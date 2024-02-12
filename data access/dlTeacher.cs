using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace data_access
{
    public class dlTeacher
    {
        public void create(Teacher t)
        {
            DB db = new DB();
            db.Teachers.Add(t);
            db.SaveChanges();
        }

        public List<Teacher> readAll()
        {
            DB db = new DB();
            return db.Teachers.ToList();
        }

        public List<Teacher> search(string s)
        {
            DB db = new DB();

            if (s == null)
                return db.Teachers.ToList();

            var q = from i in db.Teachers
                    where i.email == s || i.name == s || i.family == s
                    select i;

            return q.ToList();
        }
        public void update(Teacher t)
        {
            DB db = new DB();
            var q = from i in db.Teachers where i.id == t.id select i;
            Teacher tt = q.Single();

            tt.name = t.name;
            tt.family = t.family;
            tt.pic = t.pic;
            tt.email = t.email;

            db.SaveChanges();

        }
    }
}

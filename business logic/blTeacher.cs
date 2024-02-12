using System;
using Model;
using data_access;
using System.Collections.Generic;

namespace business_logic
{
    public class blTeacher
    {
        public void create(Teacher t)
        {
            dlTeacher dlt = new dlTeacher();
            dlt.create(t);
        }

        public List<Teacher> readAll()
        {
            dlTeacher dlt = new dlTeacher();
            return dlt.readAll();
        }
        public List<Teacher> search(string s)
        {
            dlTeacher dlt = new dlTeacher();
            return dlt.search(s);
        }
        public void update(Teacher t)
        {
            dlTeacher dlt = new dlTeacher();
            dlt.update(t);
        }
    }
}

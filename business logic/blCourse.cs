using System;
using System.Collections.Generic;
using System.Text;
using Model;
using data_access;

namespace business_logic
{
    public class blCourse
    {

        public void create(Course c , List<int> ids)
        {
            dlCourse dlc = new dlCourse();
            dlc.create(c, ids);
        }

        public List<Course> readAll()
        {
            dlCourse dlc = new dlCourse();
            return dlc.readAll();
        }
        public List<Course> search(string s)
        {
            dlCourse dlc = new dlCourse();
            return dlc.search(s);
        }
        public Course search(int id)
        {
            dlCourse dlc = new dlCourse();
            return dlc.search(id);
        }

        public List<Course> search(List<int> ids)
        {
            dlCourse dlc = new dlCourse();
            return dlc.search(ids);
        }

        public void update(Course c, List<int> ids)
        {
            dlCourse dlc = new dlCourse();
            dlc.update(c,ids);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace data_access
{
    public class DB : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-5U7BLGI\\SQL2019;database=course;trusted_connection=true;");
        }

        public DB() : base()
        {

        }
        public DB(DbContextOptions<DB> option) : base(option)
        {
            
        } 

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher_corse> TeacherCourses { get; set; }


    }
}

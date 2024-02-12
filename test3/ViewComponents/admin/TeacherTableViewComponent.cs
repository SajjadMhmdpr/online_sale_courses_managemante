using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business_logic;


namespace test3.ViewComponents 
{
    public class TeacherTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            blTeacher blt = new blTeacher();
            return View("_TeacherTable", blt.readAll());

        }
    }
}

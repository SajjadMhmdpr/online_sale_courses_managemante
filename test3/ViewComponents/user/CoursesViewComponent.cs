using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business_logic;


namespace test3.ViewComponents.user
{
    public class CoursesViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            blCourse blc = new blCourse();
            var c = blc.readAll();
            return View(c);
        }

    }
}

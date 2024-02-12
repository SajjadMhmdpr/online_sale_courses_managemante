using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business_logic;

namespace test3.ViewComponents
{
    public class TeachersViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            blTeacher blt = new blTeacher();
            var c = blt.readAll();
            return View(c);

        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using business_logic;

namespace test3.Controllers.admin
{
    public class courseController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public courseController(IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            blTeacher blt = new blTeacher();
            ViewBag.teachers = blt.readAll();
            return View();
        }

        public IActionResult create()
        {
            return View("showAll");
        }

        [HttpPost]
        public IActionResult create(Models.Course Mc)
        {
            blCourse blc = new blCourse();
            Course c = new Course();
            uploadFile file = new uploadFile(Environment);

            c.title = Mc.title;
            c.descript = Mc.descript;
            c.totalTime = Mc.totalTime;
            c.price = Mc.price;
            c.videoIntro = file.uploadVideo(Mc.videoIntro);
            c.banner = file.uploadVideo(Mc.banner);


            blc.create(c , Mc.teachers);

            return RedirectToAction(nameof(showAll));
            //return View("~/Views/couerse/showall.cshtml");
        }

        public IActionResult showAll()
        {
            //blTeacher blt = new blTeacher();
            //List<Model.Teacher> lis = new List<Teacher>();
            //if (s == "")
            //{
            //    return View("showAll", blt.readAll());
            //}
            //else
            //{
            //    lis = blt.search(s);

            //    return View("showAll", lis);
            //}

            blCourse blc = new blCourse();

            ViewBag.courses = blc.readAll();

            return View();

        }

        

        [HttpGet]
        public IActionResult search(string s)
        {
            blCourse blc = new blCourse();
            ViewBag.courses = blc.search(s);

            return View("showAll");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            blCourse blc = new blCourse();
            var c = blc.search(id);

            return View(c);
        }

        public IActionResult update(int id)
        {
            blCourse blc = new blCourse();
            Course c = blc.search(id);

            blTeacher blt = new blTeacher();
            ViewBag.teachers = blt.readAll();

            return View(c);

            //return View("~/Views/teacher/create_teacher.cshtml");
        }
        [HttpPost]
        public IActionResult update(Models.Course Mc)
        {

            blCourse blc = new blCourse();
            Course c = blc.search(Mc.id);
            uploadFile file = new uploadFile(Environment);


            c.title = Mc.title;
            c.descript = Mc.descript;
            c.totalTime = Mc.totalTime;
            c.price = Mc.price;

            if(Mc.videoIntro!=null)
            {
                c.videoIntro = file.uploadVideo(Mc.videoIntro);
            }
            if (Mc.banner != null)
            {

                c.banner = file.uploadVideo(Mc.banner);
            }



            blc.update(c,Mc.teachers);
            return RedirectToAction(nameof(showAll));
            //return View("~/Views/teacher/create_teacher.cshtml");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using business_logic;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace test3.Controllers.admin
{
    public class teacherController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public teacherController(IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View("~/Views/teacher/create_teacher.cshtml");
        }

        public IActionResult create()
        {
            return View("create_teacher");
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

            blTeacher blt = new blTeacher();

            return View("showAll", blt.readAll());

        }

        [HttpPost]
        public IActionResult create(Models.Teacher Mt)
        {
            blTeacher blt = new blTeacher();
            Teacher t = new Teacher();
            uploadFile file = new uploadFile(Environment);

            t.name = Mt.name;
            t.family = Mt.family;
            t.email = Mt.email;
            t.jensyat = Mt.jensyat;
            t.pic = file.upload(Mt.pic);


            blt.create(t);
            return RedirectToAction(nameof(showAll));
            //return View("~/Views/teacher/create_teacher.cshtml");
        }


        //[HttpPost]
        //public void create(IFormCollection data , IFormFile pic)
        //{

        //    //string name, string family


        //    blTeacher blt = new blTeacher();
        //    Teacher t = new Teacher();
        //    uploadFile file = new uploadFile(Environment);

        //    string n = data["name"];

        //    Models.Teacher tt = new Models.Teacher();

        //    tt.pic =pic;

        //    blt.create(t);
        //    //return View("~/Views/teacher/create_teacher.cshtml");
        //}

        [HttpGet]
        public IActionResult search(string s)
        {
            blTeacher blt = new blTeacher();
            List<Model.Teacher> lis = new List<Teacher>();
            lis = blt.search(s);


            return View("searchTableView", lis);

            //List<Model.Teacher> lis = new List<Teacher>();
            //lis = blt.search(s);
            //return RedirectToAction("showAll",lis);
            //return View("showAll", lis);

        }

        [HttpPost]
        public IActionResult update(Models.Teacher Mt)
        {
            blTeacher blt = new blTeacher();
            Teacher t = new Teacher();
            uploadFile file = new uploadFile(Environment);

            t.id = Mt.id;
            t.name = Mt.name;
            t.family = Mt.family;
            t.email = Mt.email;
            t.jensyat = Mt.jensyat;
            t.pic = file.upload(Mt.pic);


            blt.update(t);
            return RedirectToAction(nameof(showAll));
            //return View("~/Views/teacher/create_teacher.cshtml");
        }


    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test3.Controllers.user
{
    public class OrderController : Controller
    {
        //[Authorize]  // baraye inke faqat bad login beshe entekhab kard
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        public async Task<IActionResult> addToBasket(int coursId)
        {
            var listCours = new List<int>();

            if (HttpContext.Session.GetString("basket") != null)
            {
                listCours =
                JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();
            }

            

            listCours.Add(coursId);

            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(listCours));

            return RedirectToAction("Details", "Course", new { id = coursId });
        }

    }
}

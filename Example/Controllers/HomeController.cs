using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Example.Models;
using Newtonsoft.Json;
using System.Threading;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
          
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListUser() //Json dönen bir metodumuz var
        {
            Thread.Sleep(5000); //Loading Spinner ı görmek için metodu 5 sn bekletiyorum
            var json=JsonConvert.SerializeObject(Users.GetAll());//Listemizi Json a çevirdik
            return Json(json);
        }

        public JsonResult GetByIdUser(int id) //Json dönen bir metodumuz var
        {
            Thread.Sleep(5000); //Loading Spinner ı görmek için metodu 5 sn bekletiyorum
            var user = Users.GetById(id);
            var json = JsonConvert.SerializeObject(user);//Nesnemizi Json a çevirdik
            return Json(json);
        }

        [HttpPost]
        public JsonResult AddUser(User user)
        {
            Users.AddUser(user);
            var jsonUser = JsonConvert.SerializeObject(user);
            return Json(jsonUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

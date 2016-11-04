using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Data.Repositories;
using Forum.Models;

namespace Forum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> repository;

        public HomeController(IRepository<Post> postsRepository)
        {
            this.repository = postsRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
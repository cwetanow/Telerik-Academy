using System.Web.Mvc;
using _02.Sumator_MVC.Models;

namespace _02.Sumator_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(SumViewModel model)
        {
            model.Sum = model.FirstNumber + model.SecondNumber;

            return this.View(model);
        }
    }
}
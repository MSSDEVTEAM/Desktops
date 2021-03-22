using System.Web.Mvc;

namespace PWA_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RedirectToAction("Index", "Login");
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
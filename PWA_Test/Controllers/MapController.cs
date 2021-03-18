using PWA_Test.Models;
using System.Web.Mvc;

namespace PWA_Test.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            // Put in the dummy data in here but this should be coming from the Comparable controller
            TempData["mapData"] = new MapDetails()
            {
                longtitude = 53.40091,
                latitiude = -2.994464
            };

            MapDetails data = TempData["mapData"] as MapDetails;
            return View(data);
        }
    }
}
using PWA_Test.Models;
using System.Web.Mvc;

namespace PWA_Test.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index(string address, string postcode)
        {
            string subjectAddresslocal = "";

            // For the comparables details page
            if (TempData["subjectAddress"] != null)
                subjectAddresslocal = TempData["subjectAddress"].ToString();

            MapDetails data = new MapDetails()
            {
                address = address + ", " + postcode,
                subjectAddress = subjectAddresslocal
            };

            TempData["subjectAddress"] = subjectAddresslocal;
            return View(data);
        }
    }
}
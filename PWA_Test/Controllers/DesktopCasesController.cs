using PWA_Test.Models;
using RestSharp;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PWA_Test.Controllers
{
    public class DesktopCasesController : Controller
    {
        private PWA_TestContext db = new PWA_TestContext();

        // GET: DesktopCases
        public ActionResult Index()
        {
            return View(db.DesktopCases.ToList());
        }

        // GET: DesktopCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            ViewData["linkToComparables"] = GetLinkToComparables(desktopCases.Address, desktopCases.Postcode, desktopCases.Id);

            if (desktopCases == null)
            {
                return HttpNotFound();
            }
            return View(desktopCases);
        }

        // GET: DesktopCases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesktopCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CaseRef,PlatformRef,Address,Postcode,EstimatedVal,LoanAmount,OriginalLTV,PropertyType,PropertyStyle,Beds,Tenure,AppointmentDate,StatusId,SurveyorFK")] DesktopCases desktopCases)
        {
            if (ModelState.IsValid)
            {
                db.DesktopCases.Add(desktopCases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(desktopCases);
        }

        // GET: DesktopCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            if (desktopCases == null)
            {
                return HttpNotFound();
            }
            return View(desktopCases);
        }

        // POST: DesktopCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CaseRef,PlatformRef,Address,Postcode,EstimatedVal,LoanAmount,OriginalLTV,PropertyType,PropertyStyle,Beds,Tenure,AppointmentDate,StatusId,SurveyorFK")] DesktopCases desktopCases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desktopCases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desktopCases);
        }

        // GET: DesktopCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            if (desktopCases == null)
            {
                return HttpNotFound();
            }
            return View(desktopCases);
        }

        // POST: DesktopCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            db.DesktopCases.Remove(desktopCases);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected string GetLinkToComparables(string address, string postCode, int id)
        {
            var linkToComparables = "";

            var client = new RestClient("https://www.rightmove.co.uk/dsi/sctReport/v5");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");

            // This will be coming from selection from a list 
            request.AddParameter("application/xml",
                                  "<sctlink-request>\r\n    " +
                                    "<login>\r\n        " +
                                    "  <email>sdlcomps2020@rightmove.com</email>\r\n        " +
                                    "  <password>EWv=2!!WY!Dn6H</password>\r\n        " +
                                    "  <officeid>215927</officeid>\r\n    " +
                                    "</login>\r\n    " +
                                    "<address>\r\n        " +
                                    "  <address-line-1>" + address + "</address-line-1>\r\n        " +
                                    "  <postcode>" + postCode + "</postcode>\r\n    " +
                                    "</address>\r\n    " +
                                    "<quest-xit2-reference>" + id + "</quest-xit2-reference>\r\n" +
                                  "</sctlink-request>",
                    ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            //Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessful)
            {
                //Storing the response details recieved from web api
                var caseResponse = response.Content;

                var xml = XElement.Parse(caseResponse);

                linkToComparables = xml.Element("link").Value;
            }

            return linkToComparables;
        }
    }
}

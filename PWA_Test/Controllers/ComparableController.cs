using PWA_Test.Config;
using PWA_Test.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PWA_Test.Controllers
{
    public class ComparableController : Controller
    {
        // GET: /Comparable/5
        public ActionResult Index(int? id)
        {
            var client = new RestClient("https://rightmove.co.uk/dsi/report-details");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");

            // This will be coming from selection from a list 
            request.AddParameter("application/xml",
                "<sctcomps-request>\r\n    " + 
                ConfigSettings.LoginToRM +
                "<quest-xit2-reference>" + id + "</quest-xit2-reference>\r\n" +
                "</sctcomps-request>", 
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessful)
            {
                // Storing the response details recieved from web api
                var pass2Response = response.Content;

                XElement xml = XElement.Parse(pass2Response);

                if (xml != null)
                {
                    @ViewData["subjectAddress"] = (string)xml.Descendants("subject-property").ElementAt(0).Element("address").Element("address-line");
                    @ViewData["subjectPostcode"] = (string)xml.Descendants("subject-property").ElementAt(0).Element("address").Element("postcode");

                    IEnumerable<XElement> comparables = xml
                        .Descendants("comparables")
                        .Descendants("sales-comparables");

                    if (comparables != null)
                    {
                        var comparable = comparables
                            .Descendants("comparable-property")
                            .Select(x => new Comparable
                            {
                                postcode = (string)x.Element("address").Element("postcode"),
                                rank = (string)x.Element("rank")
                            });

                        TempData["comparables"] = comparables;

                        return View(comparable);
                    }
                }
            }
            else
            {
                ViewData["Id"] = id;
                return View("CompsIncomplete");
            }

            return View();
        }

        public ActionResult Details(string rank)
        {
            if (TempData["comparables"] != null)
            {
                IEnumerable<XElement> comparables = (IEnumerable<XElement>)TempData["comparables"];
                var parentNode = "comparable-property";
                var childNode = "rank";
                var childNodeValue = rank;
                var entries = comparables
                    .Descendants(parentNode)
                    .Where(parent => parent.Descendants(childNode)
                        .Any(child => child.Value == childNodeValue)
                    ).ToList();

                if (entries != null)
                {
                    var comparable = entries
                        .Select(x => new Comparable
                        {
                            addressLine = (string)x.Element("address").Element("address-line"),
                            postcode = (string)x.Element("address").Element("postcode"),
                            image = (string)x.Element("image"),
                            compScore = (string)x.Element("comp-score"),
                            bedrooms = (string)x.Element("bedrooms"),
                            propType = (string)x.Element("prop-type"),
                            propStyle = (string)x.Element("prop-style"),
                            floorArea = (string)x.Element("floor-area"),
                            askingPrice = (string)x.Element("asking-price"),
                            rmStatus = (string)x.Element("rm-status"),
                            distance = (string)x.Element("distance"),
                            yearBuilt = (string)x.Element("year-built")
                        }).FirstOrDefault();

                    return View(comparable);
                }
                else
                    return View("NotFound");
            }

            return View("NotFound");
        }
    }
}
using PWA_Test.Models;
using RestSharp;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PWA_Test.Controllers
{
    public class ComparableController : Controller
    {
        // GET: Case
        public ActionResult Index()
        {
            var client = new RestClient("https://rightmove.co.uk/dsi/report-details");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml");

            // This will be coming from selection from a list 
            request.AddParameter("application/xml", 
                "<sctcomps-request>\r\n    " +
                "<login>\r\n        " +
                "<email>sdlcomps2020@rightmove.com</email>\r\n        " +
                "<password>EWv=2!!WY!Dn6H</password>\r\n        " +
                "<officeid>215927</officeid>\r\n    " +
                "</login>\r\n    " +
                "<quest-xit2-reference>SB-3805566</quest-xit2-reference>\r\n" +
                "</sctcomps-request>", 
                ParameterType.RequestBody); IRestResponse response = client.Execute(request);

            // Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessful)
            {
                // Storing the response details recieved from web api
                var pass2Response = response.Content;

                var xml = XElement.Parse(pass2Response);

                if (xml != null)
                {
                    var comparables = xml
                        .Descendants("comparables")
                        .Descendants("sales-comparables");

                    if (comparables != null)
                    {
                        var comparable = comparables
                            .Descendants("comparable-property")
                            .Select(x => new Comparable
                            {
                                addressLine = (string)x.Element("address").Element("address-line"),
                                postcode = (string)x.Element("address").Element("postcode"),
                                compScore = (string)x.Element("comp-score"),
                                bedrooms = (string)x.Element("bedrooms"),
                                propType = (string)x.Element("prop-type"),
                                propStyle = (string)x.Element("prop-style"),
                                floorArea = (string)x.Element("floor-area"),
                                askingPrice = (string)x.Element("asking-price"),
                                rmStatus = (string)x.Element("rm-status"),
                                distance = (string)x.Element("distance"),
                                yearBuilt = (string)x.Element("year-built")
                            });
                        return View(comparable);
                    }
                }
            }

            return View();
        }
    }
}
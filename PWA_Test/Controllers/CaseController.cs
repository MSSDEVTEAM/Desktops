using PWA_Test.Models;
using RestSharp;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PWA_Test.Controllers
{
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Index()
        {
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
                                    "<address-line-1>15 Berrans Avenue</address-line-1>\r\n        " +
                                    "<address-line-2>Kinson</address-line-2>\r\n        " +
                                    "<address-line-3>Bournemouth</address-line-3>\r\n        " +
                                    "<postcode>BH11 9BT</postcode>\r\n    </address>\r\n    " +
                                    "<quest-xit2-reference>1234</quest-xit2-reference>\r\n" +
                                  "</sctlink-request>",
                    ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            //Checking the response is successful or not which is sent using HttpClient
            if (response.IsSuccessful)
            {
                //Storing the response details recieved from web api
                var caseResponse = response.Content;

                var xml = XElement.Parse(caseResponse);

                var model = new Case
                {
                    link = xml.Element("link").Value,
                };

                return View(model);
            }

            return View();
        }
    }
}

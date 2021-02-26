using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PWA_Test.Controllers
{
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Index()
        {
            return View();
        }

        //Hosted web API REST Service base url  
        string baseUrl = "https://www.rightmove.co.uk/dsi/sctReport/v5";

        string requestXml = @"<sctlink-request>
                                <login>
                                    <email>sdlcomps2020 @rightmove.com</email>
                                    <password>EWv=2!!WY!Dn6H</password>
                                    <officeid>215927</officeid>
                                </login>
                                <address>
                                    <address-line-1>15 Berrans Avenue</address-line-1>
                                    <address-line-2>Kinson</address-line-2>
                                    <address-line-3>Bournemouth</address-line-3>
                                    <postcode>BH11 9BT</postcode>
                                </address>
                                <quest-xit2-reference>1234</quest-xit2-reference>
                            </sctlink-request>";

        [HttpPost]
        public async Task<ActionResult> Submit()
        {
            //requestXml = requestXml.Replace("\r\n", string.Empty);

            string formattedXML = FormatXml(requestXml);

            var content = new StringContent(formattedXML, Encoding.UTF8, "application/xml");

            var httpClient = new HttpClient();

            HttpResponseMessage Res = await httpClient.PostAsync(baseUrl, content);

            //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(baseUrl))
            //{
            //    Version = HttpVersion.Version10,
            //    Content = content
            //};

            //HttpResponseMessage Res = await httpClient.SendAsync(httpRequestMessage);

            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var DevelopmentResponse = Res.Content.ReadAsStringAsync().Result;

                //dynamic json = JsonConvert.DeserializeObject(DevelopmentResponse);

            }

            //var model = new Case
            //{
            //    returnedXML = result.Content.ToString()
            //};

            //return View(model);

            return View();
        }

        string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                // Handle and throw if fatal exception here; don't just ignore them
                return xml;
            }
        }
    }
}

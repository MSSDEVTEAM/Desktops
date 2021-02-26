using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PWA_Test.Models
{
    public class Case
    {
        public Address address { get; set; }

        public int Id { get; set; }

        [DisplayName("Link to Comparables")]
        public string link { get; set; }

        [DisplayName("Right Move Reference Number")]
        public string rmReference { get; set; }
        public string returnedXML { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{
    public class Address
    {
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }

        [DisplayName("Address Line 1")]
        public string AddressLine3 { get; set; }

        [DisplayName("Post Code")]
        public string PostCode { get; set; }
    }
}
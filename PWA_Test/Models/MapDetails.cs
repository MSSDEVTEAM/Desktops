using System.ComponentModel;

namespace PWA_Test.Models
{
    public class MapDetails
    {
        [DisplayName("Longtitude")]
        public double longtitude { get; set; }

        [DisplayName("Latitiude")]
        public double latitiude { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Subject Property Address")]
        public string subjectAddress { get; set; }
    }
}
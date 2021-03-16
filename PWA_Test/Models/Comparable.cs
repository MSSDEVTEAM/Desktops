using System.ComponentModel;

namespace PWA_Test.Models
{
    public class Comparable
    {
        [DisplayName("Subject Property Address")]
        public string subjectAddress { get; set; }

        public string subjectPostcode { get; set; }

        [DisplayName("Rank")]
        public string rank { get; set; }

        [DisplayName("Address Line")]
        public string addressLine { get; set; }

        [DisplayName("Post Code")]
        public string postcode { get; set; }

        [DisplayName("Image")]
        public string image { get; set; }

        [DisplayName("Comparison Score")]
        public string compScore { get; set; }

        [DisplayName("Number of Bedrooms")]
        public string bedrooms { get; set; }

        [DisplayName("Property Type")]
        public string propType { get; set; }

        [DisplayName("Property Style")]
        public string propStyle { get; set; }

        [DisplayName("Floor Area")]
        public string floorArea { get; set; }

        [DisplayName("Asking Price")]
        public string askingPrice { get; set; }

        [DisplayName("Right Move Status")]
        public string rmStatus { get; set; }

        [DisplayName("Distance")]
        public string distance { get; set; }

        [DisplayName("Year Built")]
        public string yearBuilt { get; set; }
    }
}
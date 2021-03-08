using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PWA_Test.Models
{
    public class DesktopCases
    {
        public int Id { get; set; }

        [DisplayName("Case Ref")]
        public Nullable<int> CaseRef { get; set; }

     
        public string PlatformRef { get; set; }
        public string Address { get; set; }

        [DisplayName("Post Code")]
        public string Postcode { get; set; }

        [DisplayName("Estimated Value")]
        public Nullable<decimal> EstimatedVal { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public Nullable<decimal> OriginalLTV { get; set; }
        public string PropertyType { get; set; }
        public string PropertyStyle { get; set; }
        public Nullable<int> Beds { get; set; }
        public string Tenure { get; set; }

        [DisplayName("Today's Appointments")]
        public Nullable<System.DateTime> AppointmentDate { get; set; }

        [DisplayName("Status")]
        public Nullable<int> StatusId { get; set; }

        public Nullable<decimal> CalculatedVal { get; set; }

        public Nullable<decimal> SurveyorValuation { get; set; }

        public Nullable<decimal> NewLTV { get; set; }

        public string ComparablesLink { get; set; }
                
        public Nullable<int> SurveyorFK { get; set; }

       
        //public DesktopCaseStatus DesktopCasesStatusName { get; set; }
    }
}
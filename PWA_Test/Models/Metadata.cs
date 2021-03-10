using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PWA_Test.Models
{
    public class Desktop_CasesMetadata
    {

    }
    public class Desktop_CaseLandingMetadata
    {

    }

    public class tbl_UserMetadata
    {


        [Required]
        [Display(Name = "User Name")]
        public string UserName;

        [Required]
        [Display(Name = "Password")]
        public string UserPassword;

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "PIN must be a number")]
        public int MFAPIN;

        /* [Required]
         [EmailAddress(ErrorMessage = "Please enter a valid email address")]
         public string Email;*/
    }

    public class tbl_UserTypeMetadata
    {

    }
}
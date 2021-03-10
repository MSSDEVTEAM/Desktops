using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{
  

    public partial class UspLogin_Result
    {

        public string Error { get; set; }

        public string UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string UserType { get; set; }

        public int MFAPIN { get; set; }

        public int ActiveStep { get; set; }

    }

}

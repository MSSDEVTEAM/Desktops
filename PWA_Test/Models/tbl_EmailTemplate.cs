using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tbl_EmailTemplates
    {

        public int Id { get; set; }

        public string Desc { get; set; }

        public string Subject { get; set; }

        public string Headline { get; set; }

        public string Body { get; set; }

        public string Link { get; set; }

        public string CC { get; set; }

    }

}

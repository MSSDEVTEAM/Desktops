using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PWA_Test.Models
{
    [MetadataType(typeof(Desktop_CasesMetadata))]
    public partial class Desktop_Cases
    {
    }
    [MetadataType(typeof(Desktop_CaseLandingMetadata))]
    public partial class Desktop_CaseLanding
    {
    }
    [MetadataType(typeof(tbl_UserMetadata))]
    public partial class tbl_User
    {
    }
    [MetadataType(typeof(tbl_UserTypeMetadata))]
    public partial class tbl_UserType
    {
    }
}
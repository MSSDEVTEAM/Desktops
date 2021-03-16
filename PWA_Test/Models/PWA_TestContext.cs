using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{
    public class PWA_TestContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PWA_TestContext() : base("name=PWA_TestContext")
        {
        }

        public System.Data.Entity.DbSet<PWA_Test.Models.DesktopCases> DesktopCases { get; set; }
    }
}

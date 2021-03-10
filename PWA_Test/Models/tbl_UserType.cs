using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{

    using System;
    using System.Collections.Generic;

    public partial class tbl_UserType
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_UserType()
        {

            this.tbl_User = new HashSet<tbl_User>();

        }


        public System.Guid ID { get; set; }

        public string Type { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<tbl_User> tbl_User { get; set; }

    }

}
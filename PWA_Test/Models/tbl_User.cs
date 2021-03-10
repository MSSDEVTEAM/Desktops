using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PWA_Test.Models
{
    public partial class tbl_User
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_User()
        {

            //this.NBOS_Cases = new HashSet<NBOS_Cases>();

        }


        public System.Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public Nullable<int> Phone { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public Nullable<System.Guid> UserType { get; set; }

        public Nullable<int> FailCount { get; set; }

        public Nullable<bool> IsActive { get; set; }

        public Nullable<System.DateTime> LastLogin { get; set; }

        public Nullable<int> MFAPIN { get; set; }

        public Nullable<System.Guid> FirmID { get; set; }

        public Nullable<System.Guid> CreatedBy { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public Nullable<bool> IsExternal { get; set; }

        public Nullable<int> ActiveStep { get; set; }

        public Nullable<System.Guid> ResetUID { get; set; }

        public Nullable<System.Guid> UserStatus { get; set; }

        public Nullable<System.Guid> BSMid { get; set; }

        public Nullable<bool> IsTestUser { get; set; }

        public Nullable<System.DateTime> StartDate { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        //public virtual ICollection<NBOS_Cases> NBOS_Cases { get; set; }

        public virtual tbl_UserType tbl_UserType { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

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

        public virtual DbSet<tbl_EmailTemplates> tbl_EmailTemplates { get; set; }

        public virtual DbSet<tbl_User> tbl_User { get; set; }

        public virtual DbSet<tbl_UserType> tbl_UserType { get; set; }

        public System.Data.Entity.DbSet<PWA_Test.Models.DesktopCases> DesktopCases { get; set; }

        public virtual ObjectResult<string> f_usp_PasswordResetRequest_email(string userEmail)
        {

            var userEmailParameter = userEmail != null ?
                new ObjectParameter("userEmail", userEmail) :
                new ObjectParameter("userEmail", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("f_usp_PasswordResetRequest_email", userEmailParameter);
        }

        public virtual int usp_mfa_pin_email(string userid)
        {

            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_mfa_pin_email", useridParameter);
        }


        public virtual ObjectResult<usp_net_Login_Get_Result> usp_net_Login_Get(string username, string pwd, Nullable<System.Guid> usertype)
        {

            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));


            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));


            var usertypeParameter = usertype.HasValue ?
                new ObjectParameter("usertype", usertype) :
                new ObjectParameter("usertype", typeof(System.Guid));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_net_Login_Get_Result>("usp_net_Login_Get", usernameParameter, pwdParameter, usertypeParameter);
        }


        public virtual ObjectResult<string> usp_Password_Update(string uid, string newpass)
        {

            var uidParameter = uid != null ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(string));


            var newpassParameter = newpass != null ?
                new ObjectParameter("newpass", newpass) :
                new ObjectParameter("newpass", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_Password_Update", uidParameter, newpassParameter);
        }


        public virtual ObjectResult<string> usp_Passworduid_Check(string guid)
        {

            var guidParameter = guid != null ?
                new ObjectParameter("guid", guid) :
                new ObjectParameter("guid", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_Passworduid_Check", guidParameter);
        }


        public virtual int usp_SendEmailByTemplateId(string userid, Nullable<int> templateid)
        {

            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));


            var templateidParameter = templateid.HasValue ?
                new ObjectParameter("templateid", templateid) :
                new ObjectParameter("templateid", typeof(int));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SendEmailByTemplateId", useridParameter, templateidParameter);
        }


        public virtual ObjectResult<UspLogin_Result> UspLogin(string username, string pwd, Nullable<System.Guid> usertype)
        {

            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));


            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));


            var usertypeParameter = usertype.HasValue ?
                new ObjectParameter("usertype", usertype) :
                new ObjectParameter("usertype", typeof(System.Guid));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspLogin_Result>("UspLogin", usernameParameter, pwdParameter, usertypeParameter);
        }


        public virtual int UspCodeGen(string userid)
        {

            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UspCodeGen", useridParameter);
        }


        public virtual ObjectResult<UspPasswordresetRequestEmail_Result> UspPasswordresetRequestEmail(string userEmail)
        {

            var userEmailParameter = userEmail != null ?
                new ObjectParameter("userEmail", userEmail) :
                new ObjectParameter("userEmail", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspPasswordresetRequestEmail_Result>("UspPasswordresetRequestEmail", userEmailParameter);
        }


        public virtual ObjectResult<UspPasswordUpdate_Result> UspPasswordUpdate(string uid, string newpass)
        {

            var uidParameter = uid != null ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(string));


            var newpassParameter = newpass != null ?
                new ObjectParameter("newpass", newpass) :
                new ObjectParameter("newpass", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspPasswordUpdate_Result>("UspPasswordUpdate", uidParameter, newpassParameter);
        }


        public virtual ObjectResult<UspPasswordUidCheck_Result> UspPasswordUidCheck(string guid)
        {

            var guidParameter = guid != null ?
                new ObjectParameter("guid", guid) :
                new ObjectParameter("guid", typeof(string));


            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UspPasswordUidCheck_Result>("UspPasswordUidCheck", guidParameter);
        }
    }
}


using Proj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Proj.WebAppi.Security
{
    public class APIAuthorizeAttribute:AuthorizeAttribute
    {
        CTXContext ctx = new CTXContext();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string currentRoles = Roles;
            string userName = HttpContext.Current.User.Identity.Name;
            var product = ctx.Products.FirstOrDefault(x => x.ProductName == userName);

            if (product!=null&&currentRoles.Contains(produ)
            {

            }

           
        }
    }
}
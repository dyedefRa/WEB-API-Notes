using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi____Authorization_ile_Rollere_gore_metodlar.App_Classes
{
    public class APIAuthorize:AuthorizeAttribute
    {
        //Login olan kullanıcının rolune gore ıslem yapabılme yapamama
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var actionRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;

            var user = Tools.GetUserByName(userName);
            if (user != null&&actionRoles.Contains(user.Rol))
            {

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
          
        }
    }
}
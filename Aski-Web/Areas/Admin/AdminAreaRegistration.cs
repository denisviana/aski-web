using System.Web.Mvc;

namespace Aski_Web.Areas.Admin
{
    public class AreasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional },
                 constraints: null,
                namespaces: new[] { "Aski_Web.Areas.Admin.Controllers" }
            );
        }
    }
}
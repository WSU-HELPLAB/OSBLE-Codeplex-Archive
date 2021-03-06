using System.Web.Http;
using System.Web.Mvc;

namespace OSBLEPlus.Services.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Services",
                "APIHelp/{action}/{apiId}",
                new { controller = "APIHelp", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
﻿using System.Web.Mvc;

namespace BookShop.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BookShop.Areas.Administrator.Controllers" }
            );
        }
    }
}
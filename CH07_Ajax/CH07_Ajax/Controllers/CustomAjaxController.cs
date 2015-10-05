using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CH07_Pratice.Controllers
{
    public class CustomAjaxController : Controller
    {
        // GET: CustomAjax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            if (Request.IsAjaxRequest())
                return PartialView();

            return View();

        }
    }
}
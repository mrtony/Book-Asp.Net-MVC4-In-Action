using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CH07_Ajax.Controllers
{
    public class AjaxHelpersController : Controller
    {
        static readonly List<string> _comments = new List<string>();

        public ActionResult Index()
        {
            return View(_comments);
        }

        [HttpPost]
        public ActionResult AddComment(string comment)
        {
            _comments.Add(comment);

            if (Request.IsAjaxRequest())
            {
                ViewBag.Comment = comment;
                return PartialView();
            }

            return RedirectToAction("Index");
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult PrivacyPolicy()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }

            return View();
        }
    }
}
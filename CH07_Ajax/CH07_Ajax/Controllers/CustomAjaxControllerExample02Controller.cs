using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CH07_Ajax.Controllers
{
    public class CustomAjaxControllerExample02Controller : Controller
    {
        //建立留言清單
        private static readonly List<string> _comments = new List<string>();

        // GET: CustomAjaxControllerExample02
        public ActionResult Index()
        {
            //返回留言給檢視
            return View(_comments);
        }

        public ActionResult AddComment(string comment)
        {
            _comments.Add(comment);
            if (Request.IsAjaxRequest())
            {
                ViewBag.Comment = comment;
                return PartialView();
            }
            return RedirectToAction("Index");   //重新導向到Index
        }
    }
}
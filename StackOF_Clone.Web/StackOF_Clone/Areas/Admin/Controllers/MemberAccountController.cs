using StackOF_Clone.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOF_Clone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MemberAccountController : Controller
    {
        // GET: Admin/MemberAccount
        public ActionResult Index()
        {
            var model = new MemberViewModel();

            return View(model);
        }

        public ActionResult GetMembers()
        {
            var model = new MemberViewModel();
            var data =model.GetMemberList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
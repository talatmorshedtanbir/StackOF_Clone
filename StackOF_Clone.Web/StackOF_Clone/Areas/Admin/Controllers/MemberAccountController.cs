using StackOF_Clone.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var data = model.GetMemberList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteMember(string id)
        {
            var model = new MemberUpdateModel();            
            await model.Delete(id);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditMember(string id)
        {
            var model = new MemberUpdateModel();
            await model.Load(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMember(MemberUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await model.UpdateMember();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<ActionResult> _MemberRoles(string id)
        {
            var model = new MemberUpdateModel();
            await model.GetMemberRolesById(id);

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _MemberRoles(MemberUpdateModel model)
        {
            await model.UpdateMemberRoles();

            return RedirectToAction("Index");
        }
    }
}
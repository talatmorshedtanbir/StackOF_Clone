using StackOF_Clone.Web.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StackOF_Clone.Web.Areas.Member.Controllers
{
    public class ForumController : Controller
    {
        // GET: Member/Forum
        public ActionResult Index()
        {
            var model = new QuestionViewModel();
            model.GetQuestions();

            return View(model);
        }

        [Authorize(Roles = "Member")]
        public ActionResult PostQuestion()
        {
            var model = new PostQuestionModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostQuestion(PostQuestionModel model)
        {
            await model.Create();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var model = new QuestionUpdateModel();
            await model.DeleteQuestionById(id);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> QuestionDetails(int id)
        {
            var model = new QuestionViewModel();
            await model.GetQuestionDetails(id);

            return View(model);
        }

        public async Task<ActionResult> PostComment(QuestionViewModel model)
        {
            await model.PostComment();
            
            return RedirectToAction($"QuestionDetails/{model.Id}");
        }

        public async Task IncrementQuestionVote(int id)
        {
            var model = new QuestionUpdateModel();

            await model.QuestionVoteUpdate(id, "+");
        }
        public async Task DecrementQuestionVote(int id)
        {
            var model = new QuestionUpdateModel();

            await model.QuestionVoteUpdate(id, "-");
        }

        public async Task ApproveComment(int id)
        {
            var model = new CommentUpdateModel();

            await model.ApproveComment(id);
        }

        public async Task DeleteComment(int id)
        {
            var model = new CommentUpdateModel();

            await model.DeleteComment(id);
        }

        public async Task IncrementCommentVote(int id)
        {
            var model = new CommentUpdateModel();

            await model.CommentVoteUpdate(id, "+");
        }
        public async Task DecrementCommentVote(int id)
        {
            var model = new CommentUpdateModel();

            await model.CommentVoteUpdate(id, "-");
        }
    }
}
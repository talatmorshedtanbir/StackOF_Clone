using Microsoft.AspNet.Identity;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StackOF_Clone.Web.Areas.Member.Models
{
    public class PostQuestionModel : ForumBaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public async Task Create()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = await _memberAccountService.FindById(userId);

            var question = new Question
            {
                Title = Title,
                Description = Description,
                QuestionTime = DateTime.Now,
                VoteCount = 0,
                ApplicationUser = user
            };

            await _forumService.PostQuestion(question);
        }
    }
}
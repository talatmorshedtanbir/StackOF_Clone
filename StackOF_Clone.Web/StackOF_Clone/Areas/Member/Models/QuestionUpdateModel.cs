using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StackOF_Clone.Web.Areas.Member.Models
{
    public class QuestionUpdateModel : ForumBaseModel
    {
        public QuestionUpdateModel()
        {

        }


        public async Task DeleteQuestionById(int id)
        {
            var question = await _forumService.GetQuestion(id);

           await _forumService.DeleteQuestion(question);
        }

        public async Task QuestionVoteUpdate(int id, string option)
        {
            var question = await _forumService.GetQuestion(id);
            var email = HttpContext.Current.User.Identity.Name;
            var user = await _memberAccountService.FindByEmail(email);

            var vote = new QuestionVote
            {
                Question = question,
                ApplicationUser = user,
                UpVote = option == "+" ? true : false
            };

            await _votingService.PostQuestionVote(vote);

            question.VoteCount = option == "+" ? ++question.VoteCount : --question.VoteCount;
            await _forumService.UpdateQuestion(question);
        }
    }
}
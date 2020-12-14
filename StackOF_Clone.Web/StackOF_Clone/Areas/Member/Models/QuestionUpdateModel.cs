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
           await _forumService.DeleteQuestionAsync(id);
        }

        public async Task QuestionVoteUpdate(int id, string option)
        {
            var question = await _forumService.GetQuestion(id);
            if (option == "+")
                question.VoteCount++;
            else
                question.VoteCount--;

            await _forumService.UpdateQuestion(question);
        }
    }
}
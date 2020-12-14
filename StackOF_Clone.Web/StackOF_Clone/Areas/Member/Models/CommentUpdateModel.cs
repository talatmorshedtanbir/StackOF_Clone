using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StackOF_Clone.Web.Areas.Member.Models
{
    public class CommentUpdateModel : ForumBaseModel
    {
        public CommentUpdateModel()
        {

        }

        public async Task CommentVoteUpdate(int id, string option)
        {
            var comment = await _forumService.GetComment(id);

            if (option == "+")
                comment.VoteCount++;
            else
                comment.VoteCount--;

            await _forumService.UpdateComment(comment);
        }

        public async Task ApproveComment(int id)
        {
            var comment = await _forumService.GetComment(id);
            comment.IsApproved = true;

            await _forumService.UpdateComment(comment);
        }

        public async Task DeleteComment(int id)
        {
            await _forumService.DeleteComment(id);
        }
    }
}
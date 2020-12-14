using StackOF_Clone.Core.Entities;
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
            var email = HttpContext.Current.User.Identity.Name;
            var user = await _memberAccountService.FindByEmail(email);

            var vote = new CommentVote
            {
                Comment = comment,
                ApplicationUser = user,
                UpVote = option == "+" ? true : false
            };

            await _votingService.PostCommentVote(vote);

            comment.VoteCount = option == "+" ? ++comment.VoteCount : --comment.VoteCount;
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
            var comment = await _forumService.GetComment(id);

            await _forumService.DeleteComment(comment);
        }
    }
}
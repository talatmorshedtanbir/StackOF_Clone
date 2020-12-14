using Microsoft.AspNet.Identity;
using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StackOF_Clone.Web.Areas.Member.Models
{
    public class QuestionViewModel : ForumBaseModel
    {
        public QuestionViewModel()
        {

        }

        public IList<Question> Questions { get; set; }
        public IList<Comment> Comments { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int VoteCount { get; set; }
        public int TotalComments { get; set; }
        public ApplicationUser Questioner { get; set; }
        public DateTime QuestionTime { get; set; }
        public int CommentId { get; set; }
        public ApplicationUser Commenter { get; set; }
        public string CommentDescription { get; set; }
        public int CommentVoteCount { get; set; }
        public DateTime CommentTime { get; set; }
        public bool IsApproved { get; set; }
        public Question Question { get; set; }
        public IList<QuestionVote> QuestionVotes { get; set; }

        public void GetQuestions()
        {
            Questions = _forumService.GetAllQuestions();
        }

        public async Task GetQuestionDetails(int id)
        {
            var question = await _forumService.GetQuestion(id);
            var questionVotes = _votingService.GetQuestionVotes().Where(x => x.Question.Id == id);

            if(question != null)
            {
                Id = question.Id;
                Title = question.Title;
                Description = question.Description;
                VoteCount = question.VoteCount;
                TotalComments = question.Comments.Count;
                QuestionTime = question.QuestionTime;
                Comments = question.Comments.ToList();
                Questioner = question.ApplicationUser;
                QuestionVotes = questionVotes.ToList();
            }
        }

        public async Task PostComment()
        {
            var question = await _forumService.GetQuestion(Id);
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = await _memberAccountService.FindById(userId);

            var comment = new Comment
            {
                CommentDescription = CommentDescription,
                VoteCount = 0,
                IsApproved = false,
                CommentTime = DateTime.Now,
                ApplicationUser = user,
                Question = question
            };

            await _forumService.PostComment(comment);
        }   
    }
}
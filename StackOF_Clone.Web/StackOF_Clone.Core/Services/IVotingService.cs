using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Services
{
    public interface IVotingService : IDisposable
    {
        IList<QuestionVote> GetQuestionVotes();
        Task PostQuestionVote(QuestionVote questionVote);
        IList<CommentVote> GetCommentVotes();
        Task PostCommentVote(CommentVote commentVote);
    }
}

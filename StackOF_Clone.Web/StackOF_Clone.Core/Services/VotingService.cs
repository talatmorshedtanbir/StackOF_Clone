using StackOF_Clone.Core.Entities;
using StackOF_Clone.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Services
{
    public class VotingService : IVotingService, IDisposable
    {
        private IForumUnitOfWork _forumUnitOfWork;

        public VotingService(IForumUnitOfWork forumUnitOfWork)
        {
            _forumUnitOfWork = forumUnitOfWork;
        }

        public IList<QuestionVote> GetQuestionVotes()
        {
            return _forumUnitOfWork.QuestionVoteRepository.GetAll();
        }

        public async Task PostQuestionVote(QuestionVote questionVote)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.QuestionVoteRepository.CreateAsync(questionVote);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
        }

        public IList<CommentVote> GetCommentVotes()
        {
            return _forumUnitOfWork.CommentVoteRepository.GetAll();
        }

        public async Task PostCommentVote(CommentVote commentVote)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.CommentVoteRepository.CreateAsync(commentVote);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
        }

        public void Dispose()
        {
            _forumUnitOfWork?.Dispose();
        }
    }
}

using NHibernate;
using StackOF_Clone.Core.Entities;
using StackOF_Clone.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Services
{
    public class ForumService : IForumService, IDisposable
    {
        private IForumUnitOfWork _forumUnitOfWork;

        public ForumService(IForumUnitOfWork forumUnitOfWork)
        {
            _forumUnitOfWork = forumUnitOfWork;
        }

        public async Task PostQuestion(Question question)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.QuestionRepository.CreateAsync(question);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }        
        }

        public IList<Question> GetAllQuestions()
        {
            return _forumUnitOfWork.QuestionRepository.GetAll();
        }

        public IList<Comment> GetAllComments()
        {
            return _forumUnitOfWork.CommentRepository.GetAll();
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await _forumUnitOfWork.QuestionRepository.GetByIdAsync(id);
        }

        public async Task UpdateQuestion(Question question)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.QuestionRepository.UpdateAsync(question);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
        }

        public async Task DeleteQuestion(Question question)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.QuestionRepository.DeleteAsync(question);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
        }

        public async Task PostComment(Comment comment)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.CommentRepository.CreateAsync(comment);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _forumUnitOfWork.CommentRepository.GetByIdAsync(id);
        }

        public async Task UpdateComment(Comment comment)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.CommentRepository.UpdateAsync(comment);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
        }

        public async Task DeleteComment(Comment comment)
        {
            _forumUnitOfWork.BeginTransaction();

            try
            {
                await _forumUnitOfWork.CommentRepository.DeleteAsync(comment);
                _forumUnitOfWork.Commit();
            }
            catch
            {
                _forumUnitOfWork.Rollback();
            }
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

        public void Dispose()
        {
            _forumUnitOfWork?.Dispose();
        }
    }
}

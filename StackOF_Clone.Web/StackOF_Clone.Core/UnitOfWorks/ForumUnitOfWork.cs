using NHibernate;
using StackOF_Clone.Core.Repositories;
using StackOF_Clone.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.UnitOfWorks
{
    public class ForumUnitOfWork : UnitOfWork, IForumUnitOfWork
    {
        public IQuestionRepository QuestionRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public IQuestionVoteRepository QuestionVoteRepository { get; set; }
        public ICommentVoteRepository CommentVoteRepository { get; set; }

        public ForumUnitOfWork(ISession session, IQuestionRepository questionRepository, ICommentRepository commentRepository, IQuestionVoteRepository questionVoteRepository, ICommentVoteRepository commentVoteRepository)
            : base(session)
        {
            CommentRepository = commentRepository;
            QuestionRepository = questionRepository;
            QuestionVoteRepository = questionVoteRepository;
            CommentVoteRepository = commentVoteRepository;
        }
    }
}

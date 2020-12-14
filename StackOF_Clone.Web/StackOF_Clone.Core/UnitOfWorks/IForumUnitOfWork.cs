using StackOF_Clone.Core.Repositories;
using StackOF_Clone.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.UnitOfWorks
{
    public interface IForumUnitOfWork : IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; set; }
        ICommentRepository CommentRepository { get; set; }
    }
}

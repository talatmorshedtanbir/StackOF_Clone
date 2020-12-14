using StackOF_Clone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Services
{
    public interface IForumService : IDisposable
    {
        Task PostQuestion(Question question);
        IList<Question> GetAllQuestions();
        Task<Question> GetQuestion(int id);
        Task UpdateQuestion(Question question);
        Task DeleteQuestionAsync(int id);
        Task PostComment(Comment comment);
        Task<Comment> GetComment(int id);
        Task UpdateComment(Comment comment);
    }
}

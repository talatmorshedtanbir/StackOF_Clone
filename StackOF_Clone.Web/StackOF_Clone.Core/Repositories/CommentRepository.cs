using NHibernate;
using StackOF_Clone.Core.Entities;
using StackOF_Clone.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Core.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ISession session)
            : base(session)
        {

        }
    }
}

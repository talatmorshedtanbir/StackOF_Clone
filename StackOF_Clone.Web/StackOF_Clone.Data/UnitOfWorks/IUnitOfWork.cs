using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOF_Clone.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        void BeginTransaction();
    }
}

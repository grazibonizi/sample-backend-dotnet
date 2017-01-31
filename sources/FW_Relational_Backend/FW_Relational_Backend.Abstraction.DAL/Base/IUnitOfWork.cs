using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace FW_Relational_Backend.Abstraction.DAL.Base
{
    /// <summary>
    /// Represents a Unit Of Work, with Service Locator of needed data access objects.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();
        void SaveChangesAsync();
    }
}

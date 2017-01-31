using FW_Relational_Backend.Abstraction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using FW_Relational_Backend.DAL;
using FW_Relational_Backend.Abstraction.DTL;
using System.Reflection;
using FW_Relational_Backend.Abstraction.DAL.Base;
using System.Data;

namespace FW_Relational_Backend.DAL
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed;
        protected DbContext context;
        private DbContextTransaction activeTransaction;

        public EFUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            activeTransaction = context.Database.BeginTransaction(isolationLevel);
        }

        public void CommitTransaction()
        {
            if(activeTransaction != null)
                activeTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (activeTransaction != null)
                activeTransaction.Rollback();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            context.SaveChangesAsync();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

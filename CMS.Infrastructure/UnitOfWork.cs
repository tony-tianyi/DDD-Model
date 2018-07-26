using CMS.Domain.Core.Respository;
using CMS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        //public static readonly string connectionString = ConfigurationManager.ConnectionStrings["conn_string"].ConnectionString;
        //public SqlConnection conn = new SqlConnection(connectionString);
        private IDbContext _dbContext;
        private DbContextTransaction _dbTransaction;

        public UnitOfWork(IDbContext dbContext,IUnitOfWork unitOfWork)
        {
            //_unitOfWork = conn;
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public async Task<bool> RegisterNew<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterDirty<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterClean<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> RegisterDeleted<TEntity>(TEntity entity)
            where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        public async Task<bool> CommitAsync()
        {
            if (_dbTransaction == null)
                return await _dbContext.SaveChangesAsync() > 0;
            else
                _dbTransaction.Commit();
            return true;
        }

        public void Rollback()
        {
            if (_dbTransaction != null)
                _dbTransaction.Rollback();
        }
    }
}

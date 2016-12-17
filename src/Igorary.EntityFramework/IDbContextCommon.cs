using System;
using System.Data.Entity;

namespace Covalition.Igorary.EntityFramework
{
    public interface IDbContextCommon: IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        /// <summary>
        /// Updates relations between the objects (i.e. two-way navigation)
        /// </summary>
        void UpdateObjectGraph();

        void EnsureNewDatabase();

        DbContextTransaction BeginTransaction();
    }
}

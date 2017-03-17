using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;

namespace DataAccess
{
    public interface IHockeyLeagueContext
    {
        IQueryable<T> GetEntities<T>() where T : Entity;
        void InsertEntity<T>(T entity) where T : Entity;
        void InsertEntities<T>(IEnumerable<T> entities) where T : Entity;
        int SaveChanges();
    }

    public class HockeyLeagueContext : DbContext, IHockeyLeagueContext
    {
        public void InsertEntity<T>(T entity) where T : Entity
        {
            Set<T>().Add(entity);
        }

        public void InsertEntities<T>(IEnumerable<T> entities) where T : Entity
        {
            Set<T>().AddRange(entities);
        }

        public IQueryable<T> GetEntities<T>() where T : Entity
        {
            return Set<T>().AsQueryable();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(HockeyLeagueContext).Assembly);
        }
    }
}

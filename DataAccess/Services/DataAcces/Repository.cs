using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.DataAcces
{
    public class Repository
    {

        public IEnumerable<T> Where<T>(Func<T, bool> fct) where T : class
        {
            using var dbctx = new TodoDbContext();
            return dbctx.Set<T>().Where(fct).ToList();
        }


        public IEnumerable<T> GetAll<T>() where T : class
        {
            using var dbctx = new TodoDbContext();
            return dbctx.Set<T>().ToList();
        }

        public void Insert<T>(T entity) where T : class
        {
            using var dbctx = new TodoDbContext();
            dbctx.Entry(entity).State = EntityState.Added;
            dbctx.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            using var dbctx = new TodoDbContext();
            dbctx.Entry(entity).State = EntityState.Modified;
            dbctx.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            using var dbctx = new TodoDbContext();
            dbctx.Entry(entity).State = EntityState.Deleted;
            dbctx.SaveChanges();
        }
    }
}

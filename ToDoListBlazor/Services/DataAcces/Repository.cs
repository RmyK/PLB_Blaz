using Microsoft.EntityFrameworkCore;

namespace ToDoListBlazor.Services.DataAcces
{
    public class Repository
    {
        public IEnumerable<T> GetAll<T>() where T : class
        {
            using var dbctx = new TodoDbContext();
            return dbctx.Set<T>().ToList();
        }

        public void Insert<T>(T entity)
        {
            using var dbctx = new TodoDbContext();
            dbctx.Entry(entity).State = EntityState.Added;
            dbctx.SaveChanges();
        }

        public void Update<T>(T entity)
        {
            using var dbctx = new TodoDbContext();
            dbctx.Entry(entity).State = EntityState.Modified;
            dbctx.SaveChanges();
        }

        public void Delete<T>(T entity)
        {
            using var dbctx = new TodoDbContext();
            dbctx.Entry(entity).State = EntityState.Deleted;
            dbctx.SaveChanges();
        }
    }
}

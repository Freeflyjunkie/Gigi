using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Gigi.Repo.EF;
using Gigi.Repo.Repos.Generic.Interfaces;

namespace Gigi.Repo.Repos.Generic
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        internal GigiContext GigiContext;
        internal DbSet<T> GigiDbSet;

        public GenericRepo(GigiContext context)
        {
            GigiContext = context;
            GigiDbSet = context.Set<T>();
        }

        public IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = GigiDbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public void Add(T entity)
        {
            GigiDbSet.Add(entity);
        }

        public void Delete(object id)
        {
            T entityToDelete = GigiDbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(T entityToDelete)
        {
            if (GigiContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                GigiDbSet.Attach(entityToDelete);
            }
            GigiDbSet.Remove(entityToDelete);
        }
        
        public void Update(T entityToUpdate)
        {
            GigiDbSet.Attach(entityToUpdate);
        }       
    }
}

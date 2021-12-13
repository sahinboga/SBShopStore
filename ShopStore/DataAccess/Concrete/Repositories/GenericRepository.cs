using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
	public class GenericRepository<T> : IEntityRepository<T> where T : class
	{
		ShopContext sc = new ShopContext();
		DbSet<T> _object;

		public GenericRepository()
		{
			_object = sc.Set<T>();
		}
		public void Add(T entity)
		{
			var addedEntity = sc.Entry(entity);
			addedEntity.State = EntityState.Added;
			sc.SaveChanges();
		}

		public void Delete(T entity)
		{
			var deletedEntity = sc.Entry(entity);
			deletedEntity.State = EntityState.Deleted;
			sc.SaveChanges();
		}

		public List<T> GetAll()
		{
			return _object.ToList();
		}

		public List<T> GetAll(Expression<Func<T, bool>> filter)
		{
			return _object.Where(filter).ToList();
		}

		public T GetById(Expression<Func<T, bool>> filter)
		{
			return _object.SingleOrDefault(filter);
		}

		public void Update(T entity)
		{
			var updatedEntity = sc.Entry(entity);
			updatedEntity.State = EntityState.Modified;
			sc.SaveChanges();
		}
	}
}

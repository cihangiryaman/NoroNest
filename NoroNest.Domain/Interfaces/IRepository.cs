using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Domain.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		// Mevcutlar 
		Task Add(TEntity entity);
		void DeleteById(int id);
		void Delete(TEntity entity);
		void DeleteRange(List<TEntity> entityies);
		void Update(TEntity entity);
		Task<List<TEntity>> GetAll();
		Task<TEntity> GetById(Expression<Func<TEntity, bool>> filter);
		Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter);

		IQueryable<TEntity> GetAllAsQueryable();
		Task UpdateAsync(TEntity entity);
		// Temel CRUD
		Task AddAsync(TEntity entity);
		Task AddRangeAsync(IEnumerable<TEntity> entities);
		void UpdateRange(IEnumerable<TEntity> entities);
		void DeleteRange(IEnumerable<TEntity> entities);

		// Okuma işlemleri
		Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
		Task<List<TEntity>> GetAllAsync();
		Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);
		Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>>? filter, int pageIndex, int pageSize);

		// Seçimli Sorgular (Projection)
		Task<List<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector);
		Task<List<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);

		// Varlık Kontrolü
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
		Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);

		// İlk ve son öğe
		Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
		Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
	}
}

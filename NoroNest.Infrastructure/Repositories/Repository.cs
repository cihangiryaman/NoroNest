using Microsoft.EntityFrameworkCore;
using NoroNest.Domain.Interfaces;
using NoroNest.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		NoroNestDbContext _context;
		private DbSet<TEntity> _entitiy;

		public Repository(NoroNestDbContext context)
		{

			_context = context;
			_entitiy = _context.Set<TEntity>();
		}

		public async Task Add(TEntity entity)
		{
			await _entitiy.AddAsync(entity);
		}

		public void DeleteById(int id)
		{
			var entity = _entitiy.Find(id);
			if (entity != null)
			{
				_entitiy.Remove(entity);
			}
		}

		public void Delete(TEntity entity)
		{
			_entitiy.Remove(entity);
		}
		public void DeleteRange(List<TEntity> entityies)
		{
			_entitiy.RemoveRange(entityies);
		}

		public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
		{
			return await _entitiy.Where(filter).ToListAsync();
		}

		public async Task<List<TEntity>> GetAll()
		{
			return await _entitiy.ToListAsync();
		}

		public IQueryable<TEntity> GetAllAsQueryable()
		{
			return _entitiy.AsQueryable();
		}

		public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
		{
			var result = await _entitiy.Where(filter).ToListAsync();
			return result.FirstOrDefault();
		}

		public void Update(TEntity entity)
		{
			_entitiy.Update(entity);

		}

		public async Task AddAsync(TEntity entity) => await _entitiy.AddAsync(entity);

		public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _entitiy.AddRangeAsync(entities);

		public void UpdateRange(IEnumerable<TEntity> entities) => _entitiy.UpdateRange(entities);


		public void DeleteRange(IEnumerable<TEntity> entities) => _entitiy.RemoveRange(entities);

		public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entitiy.FirstOrDefaultAsync(filter);

		public async Task<List<TEntity>> GetAllAsync()
			=> await _entitiy.ToListAsync();

		public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entitiy.Where(filter).ToListAsync();

		public async Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>>? filter, int pageIndex, int pageSize)
		{
			var query = _entitiy.AsQueryable();
			if (filter != null)
				query = query.Where(filter);

			return await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<List<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
			=> await _entitiy.Select(selector).ToListAsync();

		public async Task<List<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector)
			=> await _entitiy.Where(filter).Select(selector).ToListAsync();

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entitiy.AnyAsync(filter);

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
		{
			if (filter != null)
				return await _entitiy.CountAsync(filter);
			return await _entitiy.CountAsync();
		}

		public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entitiy.FirstOrDefaultAsync(filter);

		public async Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entitiy.OrderByDescending(e => true).FirstOrDefaultAsync(filter); // Order zorunlu
		public async Task UpdateAsync(TEntity entity)
		{
			_entitiy.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

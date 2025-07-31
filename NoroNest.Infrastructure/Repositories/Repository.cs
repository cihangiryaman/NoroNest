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
		private DbSet<TEntity> _entities;

		public Repository(NoroNestDbContext context)
		{
			_context = context;
			_entities = _context.Set<TEntity>();
		}

		public async Task Add(TEntity entity)
		{
			await _entities.AddAsync(entity);
		}

		public void DeleteById(int id)
		{
			var entity = _entities.Find(id);
			if (entity != null)
			{
				_entities.Remove(entity);
			}
		}

		public void Delete(TEntity entity)
		{
			_entities.Remove(entity);
		}

		public void DeleteRange(List<TEntity> entityies)
		{
			_entities.RemoveRange(entityies);
		}

		public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
		{
			return await _entities.Where(filter).ToListAsync();
		}

		public async Task<List<TEntity>> GetAll()
		{
			return await _entities.ToListAsync();
		}

		public IQueryable<TEntity> GetAllAsQueryable()
		{
			return _entities.AsQueryable();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _entities.FindAsync(id);
		}

		public void Update(TEntity entity)
		{
			_entities.Update(entity);
		}

		public async Task AddAsync(TEntity entity) => await _entities.AddAsync(entity);

		public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _entities.AddRangeAsync(entities);

		public void UpdateRange(IEnumerable<TEntity> entities) =>	_entities.UpdateRange(entities);


		public void DeleteRange(IEnumerable<TEntity> entities) => _entities.RemoveRange(entities);

		public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entities.FirstOrDefaultAsync(filter);

		public async Task<List<TEntity>> GetAllAsync()
			=> await _entities.ToListAsync();

		public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entities.Where(filter).ToListAsync();

		public async Task<List<TEntity>> GetPagedAsync(Expression<Func<TEntity, bool>>? filter, int pageIndex, int pageSize)
		{
			var query = _entities.AsQueryable();
			if (filter != null)
				query = query.Where(filter);

			return await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<List<TResult>> SelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
			=> await _entities.Select(selector).ToListAsync();

		public async Task<List<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector)
			=> await _entities.Where(filter).Select(selector).ToListAsync();

		public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entities.AnyAsync(filter);

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
		{
			if (filter != null)
				return await _entities.CountAsync(filter);
			return await _entities.CountAsync();
		}

		public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entities.FirstOrDefaultAsync(filter);

		public async Task<TEntity?> LastOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
			=> await _entities.OrderByDescending(e => true).FirstOrDefaultAsync(filter); // Order zorunlu
		public async Task UpdateAsync(TEntity entity)
		{
			_entities.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}

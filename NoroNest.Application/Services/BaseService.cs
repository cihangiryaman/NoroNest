using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoroNest.Domain.Interfaces;
using NoroNest.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Application.Services
{
	public class BaseService<TEntity, TDTO>
where TEntity : class
where TDTO : class
	{
		protected readonly IRepository<TEntity> _repository;
		protected readonly IUnitOfWork _unitOfWork;
		protected readonly IMapper _mapper;

		public BaseService(IUnitOfWork unitOfWork, IMapper mapper, string keyPropertyName = "Id")
		{
			_repository = unitOfWork.GetRepository<TEntity>();
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public virtual async Task Add(TDTO entity)
		{
			await _repository.Add(_mapper.Map<TEntity>(entity));
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task Update(TDTO entity)
		{
			_repository.Update(_mapper.Map<TEntity>(entity));
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task Delete(TDTO entity)
		{
			_repository.Delete(_mapper.Map<TEntity>(entity));
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task DeleteById(int id)
		{
			_repository.DeleteById(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task DeleteRange(List<TDTO> entities)
		{
			var entityList = _mapper.Map<List<TEntity>>(entities);
			_repository.DeleteRange(entityList);
			await _unitOfWork.SaveChangesAsync();
		}

		public virtual async Task<List<TDTO>> GetAll()
		{
			var entities = await _repository.GetAll();
			return _mapper.Map<List<TDTO>>(entities);
		}

		public virtual async Task<List<TDTO>> Get(Expression<Func<TDTO, bool>> filter)
		{
			var entityFilter = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);
			var entities = await _repository.Get(entityFilter);
			return _mapper.Map<List<TDTO>>(entities);
		}

		public virtual async Task<TDTO> GetById(int id)
		{
			var entity = await _repository.GetById(id);
			return _mapper.Map<TDTO>(entity);
		}
	}
}

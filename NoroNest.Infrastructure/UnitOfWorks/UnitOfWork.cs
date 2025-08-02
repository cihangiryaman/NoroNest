using Microsoft.EntityFrameworkCore;
using NoroNest.Domain.Interfaces;
using NoroNest.Infrastructure.Contexts;
using NoroNest.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoroNest.Infrastructure.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly Dictionary<Type, object> _genericRepositories = new();

		public IRepository<T> GetRepository<T>() where T : class
		{
			var type = typeof(T);

			if (!_genericRepositories.ContainsKey(type))
			{
				var repositoryInstance = new Repository<T>(_context); // artık hata vermez
				_genericRepositories[type] = repositoryInstance;
			}

			return (IRepository<T>)_genericRepositories[type];
		}

		//public IPatientRepository Patient { get; } // örnek olarak ekledim, diğerleri de eklenecek
		private readonly NoroNestDbContext _context;

		public UnitOfWork(NoroNestDbContext context)//, IPatientRepository patientRepository)
		{
			//this.Patient = patientRepository;//örnek olarak ekledim, diğerleri de eklenecek
			_context = context;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public async Task<List<T>> QueryAsync<T>(string sql, object parameters = null) where T : class
		{
			try
			{
				using (var command = _context.Database.GetDbConnection().CreateCommand())
				{
					command.CommandText = sql;
					command.CommandType = CommandType.Text;

					if (parameters != null)
					{
						foreach (var property in parameters.GetType().GetProperties())
						{
							var param = command.CreateParameter();
							param.ParameterName = property.Name;
							param.Value = property.GetValue(parameters) ?? DBNull.Value;
							command.Parameters.Add(param);
						}
					}

					await _context.Database.OpenConnectionAsync();

					using (var result = await command.ExecuteReaderAsync())
					{
						var list = new List<T>();
						while (await result.ReadAsync())
						{
							var item = Activator.CreateInstance<T>();
							for (int i = 0; i < result.FieldCount; i++)
							{
								var name = result.GetName(i);
								var property = typeof(T).GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
								if (property != null && !result.IsDBNull(i))
								{
									var value = result.GetValue(i);
									// Nullable tipler için özel işlem
									if (value != DBNull.Value && property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
									{
										var underlyingType = Nullable.GetUnderlyingType(property.PropertyType);
										value = Convert.ChangeType(value, underlyingType);
									}
									property.SetValue(item, value);
								}
							}
							list.Add(item);
						}
						return list;
					}
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}


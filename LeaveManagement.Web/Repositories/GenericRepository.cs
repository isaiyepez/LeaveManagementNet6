using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _dbContext;

		public GenericRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}
		public async Task AddRangeAsync(List<T> entities)
		{
			await _dbContext.AddRangeAsync(entities);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int? id)
		{
			var entity = await _dbContext.Set<T>().FindAsync(id);

			if (entity != null)
			{
				_dbContext.Set<T>().Remove(entity);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<bool> ExistsAsync(int? id)
		{
			var entity = await GetByIdAsync(id);
			return entity != null;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int? id)
		{
			if (id == null)
			{
				return null;
			}

			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task<int> GetCountAsync()
		{
			return await _dbContext.Set<T>().CountAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}

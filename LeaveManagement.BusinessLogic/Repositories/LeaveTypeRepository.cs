using LeaveManagement.BusinessLogic.Contracts;
using LeaveManagement.Data;

namespace LeaveManagement.BusinessLogic.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public LeaveTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}


	}
}

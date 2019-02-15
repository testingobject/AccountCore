using Database.Services.Repository.Services;
using EF.dbmodel;
using Microsoft.EntityFrameworkCore;
using SGPC.EF.Models;

namespace Database.Services.Repository.ModelService
{
	public partial class TicketService : Repository<Ticket>
	{
		private readonly DbContext _appContext;
		public TicketService(dbcontext db) : base(db)
		{
			_appContext = (DbContext)db;
		}
	}
}

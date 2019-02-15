using AccountCore.DataModels;
using Database.Services.Repository.ModelService;
using EF.dbmodel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services.Repository.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly dbcontext _context;
		private TicketService _ticketService { get; set; }

		public UnitOfWork(dbcontext context)
        {
            _context = context;
        }


		public TicketService tickets
		{

			get
			{
				if (_ticketService == null)
				{
					_ticketService = new TicketService(_context);
				}
				return _ticketService;

			}
		}

		public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

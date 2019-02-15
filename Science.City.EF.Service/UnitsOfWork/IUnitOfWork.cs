using Database.Services.Repository.ModelService;
using System.Threading.Tasks;

namespace Database.Services.Repository.UnitsOfWork
{
    public interface IUnitOfWork
    {
		TicketService tickets { get; }
        Task<int> SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Services.Repository.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SGPC.EF.Models;
using SGPC.ViewModels;

namespace SGPC.Controllers
{
    public class TicketController : Controller
    {

		private readonly IStringLocalizer<HomeController> _localizer;
		private readonly IUnitOfWork _unitOfWork;
		public TicketController(
			IStringLocalizer<HomeController> localizer,
			IUnitOfWork unitOfWork

			)
		{
			_localizer = localizer;
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<TicketViewModel> _list = AutoMapper.Mapper.Map<List<TicketViewModel>>(_unitOfWork.tickets.GetAll().ToList());
			return View(_list);
		}


		public IActionResult Detail(Guid id) {
			TicketViewModel ticket;
			if (id != Guid.Empty)
			{
				ticket = AutoMapper.Mapper.Map<TicketViewModel>(_unitOfWork.tickets.GetFirstOrDefault(t => t.Id == id));
				return View(ticket);
			}

			return NotFound();
		}


		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(TicketViewModel ticketViewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Ticket ticket = AutoMapper.Mapper.Map<Ticket>(ticketViewModel);
					_unitOfWork.tickets.Add(ticket);
					_unitOfWork.SaveChanges();
					return View(ticketViewModel);
				}
				catch (Exception ex) {
					return View(ticketViewModel);
				}
			}
			return View(ticketViewModel);
		}
	}
}
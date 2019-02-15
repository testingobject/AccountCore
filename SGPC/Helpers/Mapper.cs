using AutoMapper;
using SGPC.EF.Models;
using SGPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPC.Helpers
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<Ticket, TicketViewModel>()
				.ForMember(d => d.Address, s => s.MapFrom(p => p.Address))
					.ForMember(d => d.Contact, s => s.MapFrom(p => p.Contact))
				.ForMember(d => d.Description, s => s.MapFrom(p => p.Description))
				.ForMember(d => d.MobileNo, s => s.MapFrom(p => p.MobileNo))
				 .ForMember(d => d.Name, s => s.MapFrom(p => p.Name))
				 .ForMember(d => d.PhoneNo, s => s.MapFrom(p => p.PhoneNo))
				 .ForMember(d => d.Subject, s => s.MapFrom(p => p.Subject))
				 .ForMember(d => d.Status, s => s.MapFrom(p => p.Status))
				.ReverseMap();
		}
	}
}

using AccountCore.DataModels;
using AccountCore.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountCore.Repositories
{
	public class AccountEmail : IAccountEmail
	{
		private readonly UserManager<ApplicationUsers> userManager;
		public AccountEmail(UserManager<ApplicationUsers> _userManager) {

			userManager = _userManager;
		}

		public async Task<(bool result, string)> GenerateEmailConfirmationTokenAsync(ApplicationUsers users)
		{
			return (true, await userManager.GenerateEmailConfirmationTokenAsync(users));
		}

		
	}
}

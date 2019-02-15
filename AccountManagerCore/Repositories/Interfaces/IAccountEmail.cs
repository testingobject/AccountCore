using AccountCore.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountCore.Repositories.Interfaces
{
	public interface IAccountEmail
	{
		Task<(bool result, string)> GenerateEmailConfirmationTokenAsync(ApplicationUsers users);
	}
}

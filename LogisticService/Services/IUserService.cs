using LogisticService.Models;
using LogisticService.Requests;
using LogisticService.Responses;

namespace LogisticService.Services
{
	public interface IUserService
	{
		Task<User> GetUser(string username);
	}
}

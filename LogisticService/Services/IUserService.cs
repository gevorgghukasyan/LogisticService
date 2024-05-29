using LogisticService.Models.Authentication;
using LogisticService.Requests;
using LogisticService.Responses;

namespace LogisticService.Services
{
    public interface IUserService
	{
		Task<User> GetUser(string username);
	}
}

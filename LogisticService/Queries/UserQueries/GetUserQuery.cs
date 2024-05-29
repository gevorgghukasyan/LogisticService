using LogisticService.Models.Authentication;
using MediatR;

namespace LogisticService.Queries.UserQueries
{
    public class GetUserQuery : IRequest<User>
	{
		public string Username { get; set; }

		public GetUserQuery(string username)
		{
			Username = username;
		}
	}
}

using LogisticService.Models.Authentication;
using LogisticService.Queries.UserQueries;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
	{
		private readonly IUserService _userService;

		public GetUserQueryHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			return await _userService.GetUser(request.Username);
		}
	}
}

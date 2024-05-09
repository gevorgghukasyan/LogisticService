using LogisticService.Commands.CarBrandCommands;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class DeleteCarBrandHandler : IRequestHandler<DeleteCarBrandCommand, bool>
	{
		public Task<bool> Handle(DeleteCarBrandCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

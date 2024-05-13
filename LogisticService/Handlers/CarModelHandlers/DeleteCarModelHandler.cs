using LogisticService.Commands.CarBrandCommands;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class DeleteCarModelHandler : IRequestHandler<DeleteCarModelCommand, bool>
	{
		public Task<bool> Handle(DeleteCarModelCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

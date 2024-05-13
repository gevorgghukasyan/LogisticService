using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class UpdateCarModelHandler : IRequestHandler<UpdateCarModelCommand, CarBrand>
	{
		public Task<CarBrand> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

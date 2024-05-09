using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class UpdateCarBrandHandler : IRequestHandler<UpdateCarBrandCommand, CarBrand>
	{
		public Task<CarBrand> Handle(UpdateCarBrandCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

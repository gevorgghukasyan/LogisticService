using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class CreateCarBrandHandler : IRequestHandler<CreateCardBrandCommand, CarBrand>
	{
		private readonly ICarBrandService _carBrandService;

		public CreateCarBrandHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public Task<CarBrand> Handle(CreateCardBrandCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

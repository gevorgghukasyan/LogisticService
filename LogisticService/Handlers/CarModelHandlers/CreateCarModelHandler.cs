using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class CreateCarModelHandler : IRequestHandler<CreateCardModelCommand, CarBrand>
	{
		private readonly ICarBrandService _carBrandService;

		public CreateCarModelHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public Task<CarBrand> Handle(CreateCardModelCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

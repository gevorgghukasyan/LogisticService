using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class CreateCarBrandHandler : IRequestHandler<CreateCarBrandCommand, CarBrand>
	{
		private readonly ICarBrandService _carBrandService;

		public CreateCarBrandHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<CarBrand> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
		{
			var carBrand = new CarBrand(request.Brand, request.Models);

			await _carBrandService.AddCarBrandAsync(carBrand);

			return carBrand;
		}
	}
}

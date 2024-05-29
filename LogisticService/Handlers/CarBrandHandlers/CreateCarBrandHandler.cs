using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class CreateCarBrandHandler : IRequestHandler<CreateCarBrandCommand, CarBrandEntity>
	{
		private readonly ICarBrandService _carBrandService;

		public CreateCarBrandHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<CarBrandEntity> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
		{
			var carBrand = new CarBrand(request.Brand, request.Models);

			await _carBrandService.AddCarBrandAsync(carBrand);

			return new CarBrandEntity() { Brand = carBrand.Brand, Models = carBrand.Models, Id = carBrand.Id };
		}
	}
}

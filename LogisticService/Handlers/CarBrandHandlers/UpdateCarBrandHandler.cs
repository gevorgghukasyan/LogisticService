using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class UpdateCarBrandHandler : IRequestHandler<UpdateCarBrandCommand, CarBrand>
	{
		private readonly ICarBrandService _carBrandService;

		public UpdateCarBrandHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<CarBrand> Handle(UpdateCarBrandCommand request, CancellationToken cancellationToken)
		{
			var carBrand = await _carBrandService.GetCarBrandByNameAsync(request.Brand);

			if (carBrand == null)
			{
				return default;
			}

			carBrand.Brand = request.Brand;
			carBrand.Models = request.Models;

			return await _carBrandService.UpdateCarBrandAsync(carBrand);
		}
	}
}

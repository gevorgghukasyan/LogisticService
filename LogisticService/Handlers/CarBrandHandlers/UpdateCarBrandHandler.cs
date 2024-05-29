using LogisticService.Commands.CarBrandCommands;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class UpdateCarBrandHandler : IRequestHandler<UpdateCarBrandCommand, CarBrandEntity>
	{
		private readonly ICarBrandService _carBrandService;

		public UpdateCarBrandHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<CarBrandEntity> Handle(UpdateCarBrandCommand request, CancellationToken cancellationToken)
		{
			var carBrand = await _carBrandService.GetCarBrandByNameAsync(request.Brand);

			if (carBrand == null)
			{
				return default;
			}

			carBrand.Brand = request.Brand;
			carBrand.Models = request.Models;

			return await _carBrandService.UpdateCarBrandAsync(new CarBrand { Id = carBrand.Id, Models = carBrand.Models, Brand = carBrand.Brand });
		}
	}
}

using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class GetCarBrandByNameHandler : IRequestHandler<GetCarBrandByBrandNameQuery, CarBrand>
	{
		private readonly ICarBrandService _carBrandService;

		public GetCarBrandByNameHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<CarBrand> Handle(GetCarBrandByBrandNameQuery request, CancellationToken cancellationToken)
		{
			return await _carBrandService.GetCarBrandByNameAsync(request.BrandName);
		}
	}
}

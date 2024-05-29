using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class GetCarBrandByNameHandler : IRequestHandler<GetCarBrandByBrandNameQuery, CarBrandEntity>
	{
		private readonly ICarBrandService _carBrandService;

		public GetCarBrandByNameHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<CarBrandEntity> Handle(GetCarBrandByBrandNameQuery request, CancellationToken cancellationToken)
		{
			return await _carBrandService.GetCarBrandByNameAsync(request.BrandName);
		}
	}
}

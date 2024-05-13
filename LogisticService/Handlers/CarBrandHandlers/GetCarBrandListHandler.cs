using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class GetCarBrandListHandler : IRequestHandler<GetCarBrandListQuery, List<CarBrand>>
	{
		private readonly ICarBrandService _carBrandService;

		public GetCarBrandListHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<List<CarBrand>> Handle(GetCarBrandListQuery request, CancellationToken cancellationToken)
		{
			return (await _carBrandService.GetCarBrandListAsync()).ToList();
		}
	}
}

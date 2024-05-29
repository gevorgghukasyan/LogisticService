using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class GetCarBrandListHandler : IRequestHandler<GetCarBrandListQuery, List<CarBrandEntity>>
	{
		private readonly ICarBrandService _carBrandService;

		public GetCarBrandListHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<List<CarBrandEntity>> Handle(GetCarBrandListQuery request, CancellationToken cancellationToken)
		{
			return (await _carBrandService.GetCarBrandListAsync()).ToList();
		}
	}
}

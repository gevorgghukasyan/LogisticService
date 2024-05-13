using LogisticService.Models.Cars;
using LogisticService.Queries.CarModelQueries;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class GetCarModelListHandler : IRequestHandler<GetCarModelListQuery, List<CarModel>>
	{
		private readonly ICarModelService _carModelService;

		public GetCarModelListHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<List<CarModel>> Handle(GetCarModelListQuery request, CancellationToken cancellationToken)
		{
			return (await _carModelService.GetCarModelListByBrandName(request.BrandName));
		}
	}
}

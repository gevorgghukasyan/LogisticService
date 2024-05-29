using LogisticService.Models.Cars;
using LogisticService.Queries.CarModelQueries;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class GetCarModelListHandler : IRequestHandler<GetCarModelListQuery, List<CarModelEntity>>
	{
		private readonly ICarModelService _carModelService;

		public GetCarModelListHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<List<CarModelEntity>> Handle(GetCarModelListQuery request, CancellationToken cancellationToken)
		{
			return (await _carModelService.GetCarModelListByBrandName(request.BrandName));
		}
	}
}

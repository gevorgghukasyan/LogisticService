using LogisticService.Models.Cars;
using LogisticService.Queries.CarModelQueries;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class GetCarModelByNameHandler : IRequestHandler<GetCarModelByModelNameQuery, CarModelEntity>
	{
		private readonly ICarModelService _carModelService;

		public GetCarModelByNameHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<CarModelEntity> Handle(GetCarModelByModelNameQuery request, CancellationToken cancellationToken)
		{
			return await _carModelService.GetCarModelAsync(request.BrandName, request.ModelName);
		}
	}
}

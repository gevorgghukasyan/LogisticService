using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class GetCarBrandListHandler : IRequestHandler<GetCarBrandListQuery, List<CarBrand>>
	{
		public Task<List<CarBrand>> Handle(GetCarBrandListQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class GetCarModelByNameHandler : IRequestHandler<GetCarBrandByBrandNameQuery, CarBrand>
	{
		public Task<CarBrand> Handle(GetCarBrandByBrandNameQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

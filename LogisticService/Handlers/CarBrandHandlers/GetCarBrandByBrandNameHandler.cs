using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class GetCarBrandByBrandNameHandler : IRequestHandler<GetCarBrandByBrandNameQuery, CarBrand>
	{
		public Task<CarBrand> Handle(GetCarBrandByBrandNameQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}

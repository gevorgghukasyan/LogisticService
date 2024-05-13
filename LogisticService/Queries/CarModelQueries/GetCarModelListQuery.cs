using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Queries.CarModelQueries
{
	public class GetCarModelListQuery : IRequest<List<CarModel>>
	{
	}
}
 
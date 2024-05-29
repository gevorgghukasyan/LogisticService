using LogisticService.Models.Cars;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Queries.CarBrandQueries
{
	public class GetCarBrandListQuery : IRequest<List<CarBrandEntity>>
	{
	}
}

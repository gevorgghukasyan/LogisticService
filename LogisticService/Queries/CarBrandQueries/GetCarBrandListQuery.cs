using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Queries.CarBrandQueries
{
	public class GetCarBrandListQuery : IRequest<List<CarBrand>>
	{
	}
}

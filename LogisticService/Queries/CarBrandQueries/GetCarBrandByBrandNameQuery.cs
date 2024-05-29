using LogisticService.Models.Cars;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Queries.CarBrandQueries
{
	public class GetCarBrandByBrandNameQuery : IRequest<CarBrandEntity>
	{
		public string BrandName { get; set; }

		public GetCarBrandByBrandNameQuery(string brandName)
		{
			BrandName = brandName;
		}
	}
}

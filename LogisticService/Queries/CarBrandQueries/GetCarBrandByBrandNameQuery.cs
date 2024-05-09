using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Queries.CarBrandQueries
{
	public class GetCarBrandByBrandNameQuery : IRequest<CarBrand>
	{
		public string BrandName { get; set; }

		public GetCarBrandByBrandNameQuery(string brandName)
		{
			BrandName = brandName;
		}
	}
}

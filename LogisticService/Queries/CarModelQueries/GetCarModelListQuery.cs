using LogisticService.Models.Cars;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Queries.CarModelQueries
{
	public class GetCarModelListQuery : IRequest<List<CarModelEntity>>
	{
		public string BrandName { get; set; }

		public GetCarModelListQuery(string brandName)
		{
			BrandName = brandName;
		}
	}
}

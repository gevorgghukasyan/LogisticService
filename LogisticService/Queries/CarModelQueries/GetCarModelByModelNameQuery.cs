using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Queries.CarModelQueries
{
	public class GetCarModelByModelNameQuery : IRequest<CarModel>
	{
		public string BrandName { get; set; }

		public GetCarModelByModelNameQuery(string brandName)
		{
			BrandName = brandName;
		}
	}
}

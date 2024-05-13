using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Queries.CarModelQueries
{
	public class GetCarModelByModelNameQuery : IRequest<CarModel>
	{
		public string BrandName { get; set; }
		public string ModelName { get; set; }

		public GetCarModelByModelNameQuery(string brandName, string modelName)
		{
			BrandName = brandName;
			ModelName = modelName;
		}
	}
}

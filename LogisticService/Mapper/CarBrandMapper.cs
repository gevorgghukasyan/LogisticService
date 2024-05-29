using LogisticService.Models.Cars;
using LogisticService.Responses;

namespace LogisticService.Mapper
{
	public class CarBrandMapper : IMapper<CarBrand, CarBrandEntity>
	{
		public CarBrandEntity Map(CarBrand input)
		{
			return new CarBrandEntity()
			{
				 Brand = input.Brand,
				 Id = input.Id,
				 Models = input.Models,
			};
		}
	}
}

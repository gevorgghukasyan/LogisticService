using LogisticService.Models.Cars;
using LogisticService.Responses;

namespace LogisticService.Mapper
{
	public class CarModelMapper : IMapper<CarModel, CarModelEntity>
	{
		public CarModelEntity Map(CarModel input)
		{
			return new CarModelEntity()
			{
				Id = input.Id,
				Name = input.Name,
				Type = input.Type,
			};
		}
	}
}

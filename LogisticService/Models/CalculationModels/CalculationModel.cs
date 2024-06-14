
using LogisticService.Models.ContainerModels;

namespace LogisticService.Models.CalculationModels
{
	public class CalculationModel
	{
		public CalculationModel(/*int id,*/ CarType carType, Direction direction, Container container)
		{
			//	Id = id;
			CarType = carType;
			Direction = direction;
			Container = container;
		}

		//	public int Id { get; set; }
		public CarType CarType { get; set; }
		public Direction Direction { get; set; }
		public Container Container { get; set; }
	}
}

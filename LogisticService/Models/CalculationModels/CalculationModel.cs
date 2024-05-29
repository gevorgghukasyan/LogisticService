namespace LogisticService.Models.CalculationModels
{
	public class CalculationModel
	{
		public CalculationModel(int id, CarType carType, Direction direction)
		{
			Id = id;
			CarType = carType;
			Direction = direction;
		}

		public int Id { get; set; }
		public CarType CarType { get; set; }
		public Direction Direction { get; set; }
	}
}

namespace LogisticService.Models.CalculationModels
{
	public class CarType
	{
		public CarType(int id, string name, float coefficient)
		{
			Id = id;
			Name = name;
			Coefficient = coefficient;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public float Coefficient { get; set; }
	}
}

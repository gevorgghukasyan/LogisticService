namespace LogisticService.Models.CalculationModels
{
	public class CarType
	{
		public CarType(int id, string name, float coefficient, string token)
		{
			Id = id;
			Name = name;
			Coefficient = coefficient;
			Token = token;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public float Coefficient { get; set; }
		public string Token { get; set; }
	}
}

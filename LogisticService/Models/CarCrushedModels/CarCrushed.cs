namespace LogisticService.Models.CarCrushedModels
{
	public class CarCrushed
	{
		public CarCrushed(bool isCrushed, float coefficient, string token)
		{
			IsCrushed = isCrushed;
			Coefficient = coefficient;
			Token = token;
		}

		public bool IsCrushed { get; set; }
		public float Coefficient { get; set; }
		public string Token { get; set; }
	}
}

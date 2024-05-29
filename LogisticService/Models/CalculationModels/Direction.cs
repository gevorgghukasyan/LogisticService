namespace LogisticService.Models.CalculationModels
{
	public class Direction
	{
		public Direction(string from, string to, float distance, float coefficient)
		{
			From = from;
			To = to;
			Distance = distance;
			Coefficient = coefficient;
		}

		public string From { get; set; }
		public string To { get; set; }
		public float Distance { get; set; }
		public float Coefficient { get; set; }
	}
}

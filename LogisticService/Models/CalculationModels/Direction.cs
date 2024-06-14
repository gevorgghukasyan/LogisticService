namespace LogisticService.Models.CalculationModels
{
	public class Direction
	{
		public Direction(string from, string to, float distance, float price, string token)
		{
			From = from;
			To = to;
			Distance = distance;
			Price = price;
			Token = token;
		}

		public string From { get; set; }
		public string To { get; set; }
		public float Distance { get; set; }
		public float Price { get; set; }
		public string Token { get; set; }
	}
}

namespace LogisticService.Models.ContainerModels
{
	public class Container
	{
		public Container(bool inClose, float coefficient)
		{
			InClose = inClose;
			Coefficient = coefficient;
		}

		public int Id { get; set; }
		/// <summary>
		/// Container type boolean value
		/// </summary>
		public bool InClose { get; set; }
		public float Coefficient { get; set; }
		public string Token { get; set; }
	}
}

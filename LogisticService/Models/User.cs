﻿namespace LogisticService.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool BlockedStatus { get; set; }
		public string Password { get; set; }
	}
}

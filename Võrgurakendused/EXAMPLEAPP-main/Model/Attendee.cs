﻿namespace ITB2203Application.Model
{
	public class Attendee
	{
		public int ID {  get; set; }

		public int EventID { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public DateTime RegistrationDate { get; set; }
	}
}

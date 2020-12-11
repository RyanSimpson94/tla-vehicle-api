using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Entities.Options
{
	public class AuthenticationOptions
	{
		public string SharedSecret { get; set; } = "Test";
		public string Issuer { get; set; } = "localhost";
		public string Audience { get; set; } = "localhost";
	}
}

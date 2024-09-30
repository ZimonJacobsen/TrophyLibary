using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLibary
{
	public class Trophy
	{
		public int Id { get; set; }
		public string Competition { get; set; }

		public int Year { get; set; }

		public override string ToString()
		{
			return $"{Id} {Competition} {Year}";
		}

		public void ValidateCompetition()
		{

			if (Competition == null)
			{
				throw new ArgumentNullException(nameof(Competition), "Competition cannot be null");
			}
			if (Competition.Length < 3)
			{
				throw new ArgumentException("Competition must contain atleast 3 characters", nameof(Competition));
			}


		}

		public void ValidateYear()
		{
			if (Year < 1970)
			{
				throw new ArgumentOutOfRangeException(nameof(Year), "Year must be 1970 or above");
			}
			if (Year < 2024)
			{
				throw new ArgumentOutOfRangeException(nameof(Year), "Year must be 2024 or lower");
			}
		}
		public void Validate()
		{
			ValidateCompetition();
			ValidateYear();
		}
	}
}

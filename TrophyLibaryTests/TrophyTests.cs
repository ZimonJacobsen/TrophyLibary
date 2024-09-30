using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLibary.Tests
{
	[TestClass()]
	public class TrophyTests
	{
		private readonly Trophy _trophy = new Trophy() { Id = 1, Competition = "Soccer", Year = 2005 };
        private readonly Trophy _nullCompetition = new Trophy() { Id = 2, Year = 1995 };
        private readonly Trophy _lowCharacterCompetition = new Trophy() { Id = 3, Competition = "aa", Year = 1997 };
        private readonly Trophy _invalidYearHigh = new Trophy() { Id = 4, Competition = "Basketball", Year = 2035 };
		private readonly Trophy _invalidYearLow = new Trophy() { Id = 5, Competition = "Basketball", Year = 1035 };
		[TestMethod()]
		public void ToStringTest()
		{
			Assert.AreEqual("1 Soccer 2005", _trophy.ToString());
		}

		[TestMethod()]
		public void ValidateCompetitionTest()
		{
			_trophy.ValidateCompetition();
			Assert.ThrowsException<ArgumentNullException>(() => _nullCompetition.ValidateCompetition());
			Assert.ThrowsException<ArgumentException>(() => _lowCharacterCompetition.ValidateCompetition());
		}

		[TestMethod()]
		public void ValidateYearTest()
		{
			_trophy.ValidateYear();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _invalidYearHigh.ValidateYear());
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _invalidYearLow .ValidateYear());
		}
	}
}
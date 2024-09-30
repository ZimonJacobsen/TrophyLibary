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
	public class TrophyRepositoryTests
	{
		
		[TestMethod()]
		public void GetTest()
		{
			TrophyRepository repository = new TrophyRepository();

			repository.Get();

			Assert.AreEqual(5, repository.Get().Count());
		}

		public void GetByIdTest()
		{
			
			TrophyRepository repository = new TrophyRepository();

		
			Trophy trophy5 = repository.GetById(5);

	
			Assert.AreEqual(5, trophy5.Id);

			Assert.IsNull(repository.GetById(9));
		}

		public void RemoveTest()
		{
			
			TrophyRepository repository = new TrophyRepository();

			
			Trophy removeTrophy = repository.Remove(5);


			Assert.AreEqual(5, removeTrophy.Id);
			Assert.AreEqual(4, repository.Get().Count()); 
		
			Assert.IsNull(repository.Remove(15));

		}
	}
}
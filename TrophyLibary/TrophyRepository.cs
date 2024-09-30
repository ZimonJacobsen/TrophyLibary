using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLibary
{
	public class TrophyRepository
	{
		private int _nextId = 1;
		private readonly List<Trophy> _trophies = new List<Trophy>();

		public TrophyRepository()
		{
			_trophies.Add(new Trophy() { Id = _nextId++, Competition = "Football", Year = 1992 });
			_trophies.Add(new Trophy() { Id = _nextId++, Competition = "Handball", Year = 2020 });
			_trophies.Add(new Trophy() { Id = _nextId++, Competition = "Icehockey", Year = 2006 });
			_trophies.Add(new Trophy() { Id = _nextId++, Competition = "Basketball", Year = 2000 });
			_trophies.Add(new Trophy() { Id = _nextId++, Competition = "Baseball", Year = 1985 });
		}
		public List<Trophy> GetAll()
		{
			return new List<Trophy>(_trophies);
		}

		public Trophy? GetById(int id)
		{
			return _trophies.Find(trophy => trophy.Id == id);
		}

		public Trophy Add(Trophy trophy)
		{
			trophy.Validate();
			trophy.Id = _nextId++;
			_trophies.Add(trophy);
			return trophy;
		}

		public Trophy? Remove(int id)
		{
			Trophy? trophy = GetById(id);
			if (trophy == null)
			{
				return null;
			}
			_trophies.Remove(trophy);
			return trophy;
		}

		public Trophy? Update(int id, Trophy trophy)
		{
			trophy.Validate();
			Trophy? existingTrophy = GetById(id);
			if (existingTrophy == null)
			{
				return null;
			}
			existingTrophy.Competition = trophy.Competition;
			existingTrophy.Year = trophy.Year;
			return existingTrophy;
		}

		public IEnumerable<Trophy> Get(int? yearAfter = null, string? orderBy = null)
		{
			IEnumerable<Trophy> result = new List<Trophy>(_trophies);

			if (yearAfter != null)
			{
				result = result.Where(t => t.Year > yearAfter);
			}
			if (orderBy != null)
			{
				orderBy = orderBy.ToLower();
				switch (orderBy)
				{
					case "title":
					case "title_asc":
						result = result.OrderBy(t => t.Competition);
						break;
					case "title_desc":
						result = result.OrderByDescending(t => t.Competition);
						break;
					case "year":
					case "year_asc":
						result = result.OrderBy(m => m.Year);
						break;
					case "year_desc":
						result = result.OrderByDescending(m => m.Year);
						break;
					default:
						break; // do nothing
							   //throw new ArgumentException("Unknown sort order: " + orderBy);
				}
			}
			return result;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using Obligatorisk_Opgave_1_2.Models;

namespace Obligatorisk_Opgave_1_2.Repositories
{
    public class TrophiesRepository
    {
        private List<Trophy> _trophies;
        private int _nextId = 1;

        public TrophiesRepository()
        {
            _trophies = new List<Trophy>
            {
                new Trophy { Id = _nextId++, Competition = "Competition1", Year = 2000 },
                new Trophy { Id = _nextId++, Competition = "Competition2", Year = 2005 },
                new Trophy { Id = _nextId++, Competition = "Competition3", Year = 2010 },
                new Trophy { Id = _nextId++, Competition = "Competition4", Year = 2015 },
                new Trophy { Id = _nextId++, Competition = "Competition5", Year = 2020 }
            };
        }

        public List<Trophy> Get(int? year = null, string sortBy = null)
        {
            var result = _trophies.ToList();

            if (year.HasValue)
            {
                result = result.Where(t => t.Year == year.Value).ToList();
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                result = sortBy.ToLower() switch
                {
                    "competition" => result.OrderBy(t => t.Competition).ToList(),
                    "year" => result.OrderBy(t => t.Year).ToList(),
                    _ => result
                };
            }

            return result;
        }

        public Trophy GetById(int id)
        {
            return _trophies.FirstOrDefault(t => t.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy Remove(int id)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                _trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy Update(int id, Trophy values)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;
            }
            return trophy;
        }
    }
}
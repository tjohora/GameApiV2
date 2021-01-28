using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Services
{
    public class MockDeveloperRepository : IDeveloperRepository
    {
        public Developer GetDeveloperById(Guid DeveloperId)
        {
            return new Developer { Id = Guid.NewGuid(), FoundedDate = DateTimeOffset.UtcNow, HeadQuarters = "earth", Name = "Business Co.", NumberOfEmployees = 20 };
        }

        public IEnumerable<Developer> GetAllDevelopers()
        {
            var developers = new List<Developer>
            {
                new Developer { Id = Guid.NewGuid(), FoundedDate = DateTimeOffset.UtcNow, HeadQuarters = "earth", Name = "Business Co.", NumberOfEmployees = 20 },
                new Developer { Id = Guid.NewGuid(), FoundedDate = DateTimeOffset.Now, HeadQuarters = "MArs", Name = "Company Ltd.", NumberOfEmployees = 100 },
                new Developer { Id = Guid.NewGuid(), FoundedDate = DateTimeOffset.UtcNow, HeadQuarters = "Ireland", Name = "BigCorp.", NumberOfEmployees = 123123 }

        };
            return developers;
        }

        public void CreateDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeveloper(Developer dev)
        {
            throw new NotImplementedException();
        }

        public Developer GetDeveloperAndGames(Guid DeveloperId)
        {
            throw new NotImplementedException();
        }
    }
}

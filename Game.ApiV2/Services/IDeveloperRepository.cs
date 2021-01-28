using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Services
{
    public interface IDeveloperRepository
    {
        IEnumerable<Developer> GetAllDevelopers();
        Developer GetDeveloperById(Guid DeveloperId);
        Developer GetDeveloperAndGames(Guid DeveloperId);
        void CreateDeveloper(Developer dev);
        void UpdateDeveloper(Developer dev);
        void DeleteDeveloper(Developer dev);
        bool SaveChanges();
    }
}

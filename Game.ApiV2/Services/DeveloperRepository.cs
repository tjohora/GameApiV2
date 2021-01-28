using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Services
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GameApiContext _context;

        public DeveloperRepository(GameApiContext context)
        {
            _context = context;
        }

        public void CreateDeveloper(Developer dev)
        {
            if(dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }
            _context.Developers.Add(dev);

        }

        public void DeleteDeveloper(Developer dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException(nameof(dev));
            }
            _context.Developers.Remove(dev);
        }

        public IEnumerable<Developer> GetAllDevelopers()
        {
            //List<Developer> devList = new List<Developer>();

            //foreach (var developer in _context.Developers)
            //{
            //    foreach (var aVideoGame in _context.VideoGames)
            //    {
            //        if (aVideoGame.DeveloperId == developer.Id)
            //        {
            //            developer.VideoGames.Add(aVideoGame);
            //        }
            //    }
            //    devList.Add(developer);
            //}
            //return devList;
            return _context.Developers.ToList();
        }

        public Developer GetDeveloperAndGames(Guid DeveloperId)
        {
            var dev = _context.Developers.FirstOrDefault(p => p.Id == DeveloperId);
            foreach (var aVideoGame in _context.VideoGames)
            {
                if (aVideoGame.DeveloperId == DeveloperId)
                {
                    dev.VideoGames.Add(aVideoGame);
                }
            }
            return dev;
        }

        public Developer GetDeveloperById(Guid DeveloperId)
        {
            return _context.Developers.FirstOrDefault(p => p.Id == DeveloperId);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateDeveloper(Developer dev)
        {
            //Nothing
        }
    }
}

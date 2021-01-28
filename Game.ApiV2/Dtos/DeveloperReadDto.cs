using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Dtos
{
    public class DeveloperReadDto
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public int Age { get; set; }

        public string HeadQuarters { get; set; }

        public ICollection<VideoGame> VideoGames { get; set; }
            = new List<VideoGame>();
    }
}

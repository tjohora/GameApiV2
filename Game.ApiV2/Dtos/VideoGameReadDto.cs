using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Dtos
{
    public class VideoGameReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid DeveloperId { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string Genres { get; set; }

        public string Description { get; set; }

        //public ICollection<Review> Reviews { get; set; }
        //    = new List<Review>();
    }
}

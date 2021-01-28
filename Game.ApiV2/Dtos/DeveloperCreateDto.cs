using Game.ApiV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Dtos
{
    public class DeveloperCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset FoundedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string HeadQuarters { get; set; }

        [Required]
        public int NumberOfEmployees { get; set; }

        //public ICollection<VideoGame> VideoGames { get; set; }
        //    = new List<VideoGame>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Dtos
{
    public class VideoGameCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public Guid DeveloperId { get; set; }

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre1 { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre2 { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}

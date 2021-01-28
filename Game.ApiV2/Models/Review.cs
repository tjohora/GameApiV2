using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Game.ApiV2.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [ForeignKey("VideoGameId")]
        public VideoGame VideoGame { get; set; }

        public Guid VideoGameId { get; set; }
    }
}

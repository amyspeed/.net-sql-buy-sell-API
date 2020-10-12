using System;
using System.ComponentModel.DataAnnotations;

namespace buy_and_sell_dotNetAPI.Dtos
{
    public class ListingUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [MaxLength(36)]
        public string UserId { get; set; }

        public int Views { get; set; }
    }
}

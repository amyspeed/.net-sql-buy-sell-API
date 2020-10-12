using System;
namespace buy_and_sell_dotNetAPI.Dtos
{
    public class ListingReadDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string UserId { get; set; }

        public int Views { get; set; }
    }
}

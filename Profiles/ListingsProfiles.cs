using System;
using AutoMapper;
using buy_and_sell_dotNetAPI.Dtos;
using buy_and_sell_dotNetAPI.Models;

namespace buy_and_sell_dotNetAPI.Profiles
{
    public class ListingsProfiles : Profile
    {
        public ListingsProfiles()
        {
            CreateMap<Listing, ListingReadDto>();

            CreateMap<ListingCreateDto, Listing>();

            CreateMap<ListingUpdateDto, Listing>();

            CreateMap<Listing, ListingUpdateDto>();
        }
    }
}

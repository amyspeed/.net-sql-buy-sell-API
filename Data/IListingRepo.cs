using System;
using System.Collections.Generic;
using buy_and_sell_dotNetAPI.Models;

namespace buy_and_sell_dotNetAPI.Data
{
    public interface IListingRepo
    {
        bool SaveChanges();

        IEnumerable<Listing> GetAllListings();

        Listing GetListingById(int Id);

        void CreateListing(Listing lst);

        void UpdateListing(Listing lst);

        void DeleteListing(Listing lst);
    }
}

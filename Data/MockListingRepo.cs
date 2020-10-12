using System;
using System.Collections.Generic;
using buy_and_sell_dotNetAPI.Models;

namespace buy_and_sell_dotNetAPI.Data
{
    public class MockListingRepo : IListingRepo
    {
        public void CreateListing(Listing lst)
        {
            throw new NotImplementedException();
        }

        public void DeleteListing(Listing lst)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Listing> GetAllListings()
        {
            var listings = new List<Listing>
            {
                new Listing { Id = 223, Name = "Test Name2", Description="Test Desc" },
                new Listing { Id = 224, Name = "Test Name3", Description="Test Desc" },
                new Listing { Id = 225, Name = "Test Name4", Description="Test Desc" }
            };

            return listings;
        }

        public Listing GetListingById(int Id)
        {
            return new Listing { Id = 222, Name = "Test Name" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateListing(Listing lst)
        {
            //nothing
        }
    }
}

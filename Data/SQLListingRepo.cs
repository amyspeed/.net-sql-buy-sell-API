using System;
using System.Collections.Generic;
using System.Linq;
using buy_and_sell_dotNetAPI.Models;

namespace buy_and_sell_dotNetAPI.Data
{
    public class SQLListingRepo : IListingRepo
    {
        private readonly ApplicationDBContext _context;

        public SQLListingRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _context.Listings.ToList();
        }

        public Listing GetListingById(int id)
        {
            return _context.Listings.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateListing(Listing lst)
        {
            if (lst == null)
            {
                throw new ArgumentNullException(nameof(lst));
            }

            _context.Listings.Add(lst);
        }

        public void UpdateListing(Listing lst)
        {
            //Nothing
        }

        public void DeleteListing(Listing lst)
        {
            if (lst == null)
            {
                throw new ArgumentNullException(nameof(lst));
            }

            _context.Listings.Remove(lst);
        }
    }
}

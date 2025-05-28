using Back2Retro.Dal;
using Back2Retro.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Back2Retro.DAL
{
    public class ReviewRepository
    {
        private readonly Back2RetroDbContext _context = new Back2RetroDbContext();

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public List<Review> GetByProductId(int productId)
        {
            return _context.Reviews
                .Where(r => r.ProductId == productId)
                .OrderByDescending(r => r.DatePosted)
                .ToList();
        }
    }
}
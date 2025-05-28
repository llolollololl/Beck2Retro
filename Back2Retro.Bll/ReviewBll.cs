using Back2Retro.DAL;
using Back2Retro.Entities;
using System;
using System.Collections.Generic;

namespace Back2Retro.BLL
{
    public class ReviewService
    {
        private readonly ReviewRepository _repo = new ReviewRepository();

        public void AddReview(Review review)
        {
            _repo.Add(review);
        }

        public List<Review> GetReviewsByProductId(int productId)
        {
            return _repo.GetByProductId(productId);
        }

        public List<Review> GetReviewsForProduct(int id)
        {
            return _repo.GetByProductId(id); // просто проксирует вызов в репозиторий
        }
    }
}

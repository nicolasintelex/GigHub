using GigHub.Models;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool GetFollowing(Gig gig , string userId)
        {
            return gig.Artist.Followers.Any(f => f.FollowerId == userId);
        }
    }
}
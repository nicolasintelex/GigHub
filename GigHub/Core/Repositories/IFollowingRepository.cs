using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        bool GetFollowing(Gig gig, string userId);
        IEnumerable<ApplicationUser> GetFollowings(string userId);
    }
}
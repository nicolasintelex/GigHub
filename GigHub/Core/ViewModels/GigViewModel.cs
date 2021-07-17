using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class GigViewModel
    {
        public Gig Gig { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsGoing { get; set; }

    }
}
using GigHub.Models;


namespace GigHub.ViewModels
{
    public class GigViewModel
    {
        public Gig Gig { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsGoing { get; set; }

    }
}
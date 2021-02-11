using GigHub.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Controllers.API
{
    public class NotificationDto
    {
        public DateTime Datetime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public GigDto Gig { get;  set; }
    }
}
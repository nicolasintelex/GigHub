﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime Datetime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {

        }

        private Notification(Gig gig, NotificationType type) 
        {
            if (gig == null)
            {
                throw new ArgumentNullException("gig");
            }

            Datetime = DateTime.Now;
            Type = type;
            Gig = gig;    
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCreated);
        }

        public static Notification GigUpdated(Gig Newgig, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(Newgig, NotificationType.GigUpdated);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }

    }

}
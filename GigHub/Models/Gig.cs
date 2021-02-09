using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool isCancelled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

      
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public ICollection<Attendance> Attendances{ get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            isCancelled = true;

            var notification = Notification.GigCanceled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        internal void Modify(DateTime datetime, string venue, byte genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            DateTime = datetime;
            Venue = venue;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}
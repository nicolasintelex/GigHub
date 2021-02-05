using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers.API
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {   
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            if (gig.isCancelled)
            {
                return NotFound();
            }

            gig.isCancelled = true;
            var notification = new Notification
            {
                Datetime = DateTime.Now,
                Gig = gig,
                Type = NotificationType.GigCanceled
            };

            var attendees = _context.Attendances
                .Where(a => a.GigId == gig.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach (var attendee in attendees)
            {
                var userNotification = new UserNotification
                {
                    User = attendee,
                    Notification = notification
                };

                _context.UserNotification.Add(userNotification);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}

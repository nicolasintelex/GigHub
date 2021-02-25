using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using AutoMapper;
using GigHub.App_Start;
using GigHub.Dtos;

namespace GigHub.Controllers.API
{
    [Authorize]
    public partial class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNewNotification()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(AutoMapperConfig.mapper.Map<Notification, NotificationDto>);

        }

        [HttpPost]
        public IHttpActionResult ReadNotifications()
        {
            var userId = User.Identity.GetUserId();
            var userNotifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            foreach (var notification in userNotifications)
            {
                notification.IsRead = true;
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}

﻿using GigHub.Dtos;
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
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _context;
        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Following.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("the following already exists");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Following.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}

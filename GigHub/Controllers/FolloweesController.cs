﻿using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;
        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Following
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(artists);
        }
    }
}
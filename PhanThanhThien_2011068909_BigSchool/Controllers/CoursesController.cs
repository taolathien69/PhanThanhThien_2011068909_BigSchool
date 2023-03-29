using Microsoft.AspNet.Identity;
using PhanThanhThien_2011068909_BigSchool.Models;
using PhanThanhThien_2011068909_BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanThanhThien_2011068909_BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController() 
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses

        [Authorize]
        
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList(),
            };
            return View(viewModel);
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create",viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Attendances.Where(a=>a.AttendeeId == userId).Select(a=>a.Course).Include(l=>l.Lecturer).Include(l=>l.Category).ToList();
            var viewModel = new CoursesViewModel
            {
                UpcommingCourse = course,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var followings = _dbContext.Followings
                //.Where(f => f.FolloweeId == userId)
                .Include(d => d.Followee)
                // .Include(e => e.Follower)

                .ToList();
            return View(followings);
        }
    }
}
using Microsoft.AspNet.Identity;
using PhanThanhThien_2011068909_BigSchool.DTOs;
using PhanThanhThien_2011068909_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhanThanhThien_2011068909_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController() 
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exist!");
            var following = new Following { FollowerId = userId,  FolloweeId = followingDto.FolloweeId  /*User.Identity.GetUserId()*/ };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

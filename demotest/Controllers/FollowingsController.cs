using demotest.DTOs;
using demotest.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demotest.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow( FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId==followingDto.FolloweeId))
                return (IHttpActionResult)BadRequest("The Attendance already exists!!");
            var folowing = new Following
            {
                FolloweeId = userId,
                FollowerId = followingDto.FolloweeId

            };
            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();
            return (IHttpActionResult)Ok();
        }
    }
}

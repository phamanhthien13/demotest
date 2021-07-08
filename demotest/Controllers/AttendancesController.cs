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
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseID))
                return (IHttpActionResult)BadRequest("The Attendance already exists!!");
            var attedance = new Attendance
            {
                CourseId = attendanceDto.CourseID,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attedance);
            _dbContext.SaveChanges();
            return (IHttpActionResult)Ok();
        }

    }
}

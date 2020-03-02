using ActiviList.Models;
using ActiviList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActiviList.WebAPI.Controllers
{
    [Authorize]
    public class SubActivityController : ApiController
    {
        public IHttpActionResult Post(SubActivityCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSubActivityService();
            if (!service.Create(model))
                return InternalServerError();
            return Ok();
        }

        
        private SubActivityService CreateSubActivityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var subActivityService = new SubActivityService(userId);
            return subActivityService;
        }
    }
}

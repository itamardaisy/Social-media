using Common;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdentityService.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityManager bl;

        public IdentityController(IIdentityManager manager)
        {
            bl = manager;
        }

        /// <summary>
        /// Add userIdentity to db using http call from the client
        /// </summary>
        [HttpPost]
        [Route("api/Identity/{name}")]
        public HttpResponseMessage CreateUserIdentity(string name, int age, string address, string workAddress)
        {
            try
            {
                bl.AddUser(name, age, address, workAddress);
                return Request.CreateResponse(HttpStatusCode.OK, "User added successfully");
            }
            catch (HttpResponseException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// get useridentity
        /// </summary>
        [Route("api/Identity/{name}")]
        public HttpResponseMessage GetUserIdentity(string name)
        {
            try
            {
                var user = bl.GetUser(name);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (KeyNotFoundException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}

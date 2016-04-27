using DemoAngularWebAPI.API;
using DemoAngularWebAPI.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAngularWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Comment")]
    public class CommentController : ApiController
    {
        private AuthContext _ctx = new AuthContext();

        [Route("")]
        public IHttpActionResult GetByTaskID(int taskID)
        {
            var result = _ctx.Comments.Where(x => x.TaskID == taskID).ToList();

            return Ok(result);
        }

        [Route("Post")]
        public IHttpActionResult Post(Comments comment)
        {
            try
            {
                _ctx.Comments.Add(comment);
                _ctx.SaveChanges();

                return Ok(comment.TaskID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        public IHttpActionResult Delete(int commentID)
        {
            try
            {
                Comments comments = _ctx.Comments.Where(c => c.Id == commentID).FirstOrDefault();
                _ctx.Comments.Remove(comments);
                _ctx.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

    }
}

using DemoAngularWebAPI.API;
using DemoAngularWebAPI.API.Entities;
using DemoAngularWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAngularWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Task")]
    public class TaskController : ApiController
    {
        private AuthContext _ctx = new AuthContext();

        //GET: api/product
        [Route("")]
        public IHttpActionResult Get()
        {
            var task = _ctx.Tasks.ToList();

            var comment = _ctx.Comments.ToList();

            List<TaskModel> lstTask = new List<TaskModel>();

            foreach (var taskItem in task)
            {
                TaskModel taskModel = new TaskModel();

                taskModel.TaskID = taskItem.Id;
                taskModel.Title = taskItem.Title;
                taskModel.DueDate = taskItem.DueDate;
                taskModel.Label = taskItem.Label;
                taskModel.Description = taskItem.Descriptions;
                taskModel.Comments = comment.Where(c => c.TaskID == taskItem.Id).ToList();

                //Check due date
                if (taskItem.DueDate >= DateTime.Now)
                {
                    taskModel.RowClass = "";
                }
                else
                {
                    taskModel.RowClass = "red";
                }

                lstTask.Add(taskModel);
            }

            return Ok(lstTask);
        }

        [Route("Post")]
        public IHttpActionResult Post(TaskModel taskModel)
        {
            try
            {
                Tasks objTask = new Tasks();
                objTask.Title = taskModel.Title;
                objTask.Descriptions = taskModel.Description;
                objTask.DueDate = taskModel.DueDate;
                objTask.Label = taskModel.Label;

                _ctx.Tasks.Add(objTask);
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

using DomainModel;
using ServiceModel;
using ServiceModel.DTO;
using ServiceModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace REST_WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        [Route("api/taskfromuser/{userId}")]
        [HttpGet]
        public IEnumerable<TaskDTO> GetTasksFromUser(int userId)
        {
            TaskService service = new TaskService();
            return service.ListTasks(userId);
        }

        // GET: api/Task/5
        public TaskDTO Get(int id)
        {
            TaskService service = new TaskService();
            return service.ReadTask(id);
        }

        public int Post([FromBody]TaskDTO dto)
        {
            TaskService service = new TaskService();
            var Id = service.CreateTask(dto);
            return Id;
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]TaskDTO model)
        {
            model.Id = id;
            TaskService service = new TaskService();
            service.UpdateTask(model);
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
            TaskService service = new TaskService();
            service.DeleteTask(id);
        }
    }
}

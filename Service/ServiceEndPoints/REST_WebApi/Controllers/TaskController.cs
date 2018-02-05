using DomainModel;
using ServiceModel;
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
        // GET: api/Task
        public IEnumerable<Task> Get()
        {
            TaskService service = new TaskService();
            return service.ListTasks();
        }

        // GET: api/Task/5
        public Task Get(int id)
        {
            TaskService service = new TaskService();
            return service.ReadTask(id);
        }

        // POST: api/Task
        public int Post([FromBody]Task model)
        {
            TaskService service = new TaskService();
            var Id = service.CreateTask(model);
            return Id;
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]Task model)
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

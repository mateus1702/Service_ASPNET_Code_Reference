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
    public class UserController : ApiController
    {
        // GET: api/User
        public IEnumerable<UserDTO> Get()
        {
            UserService service = new UserService();
            return service.ListUsers();
        }

        // GET: api/User/5
        public UserDTO Get(int id)
        {
            UserService service = new UserService();
            return service.ReadUser(id);
        }

        // POST: api/User
        public int Post([FromBody]UserDTO dto)
        {
            UserService service = new UserService();
            var Id = service.CreateUser(dto);
            return Id;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]UserDTO dto)
        {
            dto.Id = id;
            UserService service = new UserService();
            service.UpdateUser(dto);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            UserService service = new UserService();
            service.DeleteUser(id);
        }
    }
}

using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IRepository<Entity,int>
        where Entity : class
    {
        Repository repository;
        public BaseController(Repository repository)
        {
            this.repository= repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = repository.Get();
            return Ok(new { Message = "Data Has been Retrivied", StatusCode = 200, Data = data });

        }

        [HttpGet("{Id}")]

        public IActionResult Get(int id)
        {
            var data = repository.Get(id);
            return Ok(new { Message = "Data Has been Retrivied", StatusCode = 200, Data = data });
        }

        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            var data = repository.Create(entity);
            return Ok(new { Message = "Data Has been Created", StatusCode = 200, Data = data });
        }
        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            var data = repository.Update(entity);
            return Ok(new { Message = "Data Has been Updated", StatusCode = 200, Data = data });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = repository.Delete(id);
            return Ok(new { Message = "Data Has been Deleted", StatusCode = 200, Data = data });
        }

    }
}

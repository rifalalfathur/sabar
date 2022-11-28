
using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionControllerNew : BaseController<DivisionRepositoryNew,Division>
    {
        DivisionRepositoryNew _repositories;

        public DivisionControllerNew(DivisionRepositoryNew repositoryNew) : base(repositoryNew)
        {
            _repositories = repositoryNew;
        }
        [HttpGet("{Name}")]
        public IActionResult Get(string Name)
        {
            var data = _repositories.Get(Name);
            return Ok(new {Message= "data has been retrieved", StatusCode = 200, Data = data});
        }

       
    }
}

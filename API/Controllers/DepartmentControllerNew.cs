using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentControllerNew : BaseController<DepartmentRepositoryNew,Department>
    {
        DepartmentRepositoryNew departmentRepositoryNew;
        public DepartmentControllerNew (DepartmentRepositoryNew department) : base(department)
        {
            departmentRepositoryNew = department;
        }
    }
}

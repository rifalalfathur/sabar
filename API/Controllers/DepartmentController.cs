using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentRepositories DepRepositories;
        public DepartmentController(DepartmentRepositories departmentRepositories)
        {
            DepRepositories = departmentRepositories;
        }
        //Get All
        //[Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var data = DepRepositories.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ada"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data  ada",
                        Data = data 
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });

            }
        }
        //Get By Id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var data = DepRepositories.Get(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ada"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data  ada",
                        Data = data
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });
            }

        }


        //Create
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                var data = DepRepositories.Create(department);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Berhasil Disimpan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Disimpan",
                        Data =data 
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });
            }
            
        }

        //Update
        [HttpPut]
        public ActionResult Update(Department department)
        {

            try
            {
                var data = DepRepositories.Update(department);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Berhasil Di-Update"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data  Berhasil Di-Update",
                        Data =  data
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });
            }

        }

        //Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            try
            {
                var data = DepRepositories.Delete(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Berhasil Dihapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data  Berhasil Dihapus",
                        Data = data 
                    });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = e.Message
                });
            }
            
        }
    }
}

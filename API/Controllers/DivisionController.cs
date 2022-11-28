using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private DivisionRepositories DivRepositories;
        public DivisionController(DivisionRepositories divisionRepositories)
        {
            DivRepositories = divisionRepositories;
        }

        //Get All
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var data = DivRepositories.Get();
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
                        data = data
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
                var data = DivRepositories.Get(id);
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


        //Create
        [HttpPost]
        public ActionResult Create(Division division)
        {
            try
            {
                var data = DivRepositories.Create(division);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak Berhasil Disimpan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Disimpan",
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

        //Update
        [HttpPut]
        public ActionResult Update(Division division)
        {
            try
            {
                var data = DivRepositories.Update(division);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Update"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Diupdate",
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

        //Delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = DivRepositories.Delete(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Dihapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Dihapus",
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

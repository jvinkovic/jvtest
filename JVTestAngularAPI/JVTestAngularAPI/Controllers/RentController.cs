using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Logic;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JVTestAngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : Controller
    {
        public readonly RentService _service;

        public RentController(RentService service)
        {
            _service = service;
        }

        [HttpGet("")]
        [Produces(typeof(IEnumerable<RentModel>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [Produces(typeof(RentModel))]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        [Produces(typeof(long))]
        public async Task<IActionResult> Create([FromBody] RentModelBase rent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _service.Create(rent));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured. Please, try again.");
            }
        }

        [HttpPost("return/{id}")]
        [Produces(typeof(long))]
        public async Task<IActionResult> Return(long id)
        {
            try
            {
                await _service.Return(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured. Please, try again.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var success = await _service.Delete(id);

                if (success)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

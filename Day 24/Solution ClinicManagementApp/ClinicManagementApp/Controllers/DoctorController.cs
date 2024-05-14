using ClinicManagementApp.Models;
using ClinicManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public  DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpPost("AddDoctor")]

        public async Task<ActionResult<int>> Post([FromBody]Doctor doctor)
        {
            try
            {
                var result = await _service.AddDoctor(doctor);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Doctor/{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            try
            {
                var result = await _service.GetDoctorById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Doctor/specialization/{specialization}")]

        public async Task<ActionResult<List<Doctor>>> GetDoctorBySpecialization(string specialization)
        {
            try
            {
                var result =await _service.GetDoctorBySpecialization(specialization);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}

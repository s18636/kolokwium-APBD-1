using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolos_APBD.Models;
using kolos_APBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolos_APBD.Controllers
{
    [Route("api/prescription")]
    public class PrescriptionController : ControllerBase
    {

        private IDbService _dbService;

        public PrescriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Prescription pr = _dbService.GetPrescription(id);

            return Ok(pr);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

    }
}

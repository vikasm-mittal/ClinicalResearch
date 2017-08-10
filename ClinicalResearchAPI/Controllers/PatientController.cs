using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinicalResearchAPI.Context;
using Models.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClinicalResearchAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Patient")]
    //[Authorize]
    public class PatientController : Controller
    {
        private PatientContext _patientContext;

        public PatientController(PatientContext patientContext)
        {
            _patientContext = patientContext;
        }

        // GET: api/Patient
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _patientContext.Patients.ToList();
        }

        // GET: api/patient/doctor/3 -- get all patients for doctor with id 3
        [HttpGet("doctor/{id}")]
        public string GetByDoctor(int id)
        {
            
            return "value";
        }       
        
        // POST: api/Patient
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

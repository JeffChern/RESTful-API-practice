using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveApi.Repository;
using ReserveApi.Models;

namespace ReserveApi.Controllers
{
    [Produces("application/json")]    
    [Route("api/Patients")]
    public class PatientsController : Controller
    {
        private readonly IPatientsRepository patientsRepository;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            this.patientsRepository = patientsRepository;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await patientsRepository.GetAllPatients());
        }

        // GET: api/Patients/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var patients = await patientsRepository.GetPatients(id);

            if (patients == null)
                return new NotFoundResult();

            return new ObjectResult(patients);
        }

        // POST: api/Patients
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Patients patients)
        {
            await patientsRepository.Create(patients);
            return new OkObjectResult(patients);
        }

        // PUT: api/Patients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Patients patients)
        {
            var patientFromDb = await patientsRepository.GetPatients(id);

            if (patientFromDb == null)
                return new NotFoundResult();

            patients.Id = patientFromDb.Id;

            await patientsRepository.Update(patients);

            return new OkObjectResult(patients);
        }

        // DELETE: api/Patients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var patientFromDb = await patientsRepository.GetPatients(id);

            if (patientFromDb == null)
                return new NotFoundResult();

            await patientsRepository.Delete(id);

            return new OkResult();
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveApi.Repository;
using ReserveApi.Models;

namespace ReserveApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Appointments")]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsRepository appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            this.appointmentsRepository = appointmentsRepository;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await appointmentsRepository.GetAllAppointments());
        }

        // GET: api/Appointments/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var appointments = await appointmentsRepository.GetAppointments(id);

            if (appointments == null)
                return new NotFoundResult();

            return new ObjectResult(appointments);
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Appointments appointments)
        {
            await appointmentsRepository.Create(appointments);
            return new OkObjectResult(appointments);
        }

        // PUT: api/Appointments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Appointments appointments)
        {
            var aptFromDb = await appointmentsRepository.GetAppointments(id);

            if (aptFromDb == null)  
                return new NotFoundResult();

            appointments.Id = aptFromDb.Id;
            await appointmentsRepository.Update(appointments);

            return new OkObjectResult(appointments);
        }

        // DELETE: api/Appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var aptFromDb = await appointmentsRepository.GetAppointments(id);

            if (aptFromDb == null)
                return new NotFoundResult();

            await appointmentsRepository.Delete(id);

            return new OkResult();
        }
    }
}

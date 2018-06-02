using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveApi.Repository;
using ReserveApi.Models;

namespace ReserveApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Practice")]
    public class PracticeController : Controller
    {
        private readonly IPracticeRepository practiceRepository;

        public PracticeController(IPracticeRepository practiceRepository)
        {
            this.practiceRepository = practiceRepository;
        }

        // GET: api/Practice
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await practiceRepository.GetAllPractice());
        }

        // GET: api/Practice/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var practice = await practiceRepository.GetPractice(id);

            if (practice == null)
                return new NotFoundResult();

            return new ObjectResult(practice);
        }

        // POST: api/Practice
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Practice practice)
        {
            await practiceRepository.Create(practice);
            return new OkObjectResult(practice);
        }

        // PUT: api/Practice/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Practice practice)
        {
            var practiceFromDb = await practiceRepository.GetPractice(id);

            if (practiceFromDb == null)
                return new NotFoundResult();

            practice.Id = practiceFromDb.Id;

            await practiceRepository.Update(practice);

            return new OkObjectResult(practice);
        }

        // DELETE: api/Practice/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var practiceFromDb = await practiceRepository.GetPractice(id);

            if (practiceFromDb == null)
                return new NotFoundResult();

            await practiceRepository.Delete(id);

            return new OkResult();
        }
    }
}

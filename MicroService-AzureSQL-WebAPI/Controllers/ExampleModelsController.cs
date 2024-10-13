using Microsoft.AspNetCore.Mvc;
using AzureSQLWebAPIMicroservice.Models;
using AzureSQLWebAPIMicroservice.Services;
using System.Threading.Tasks;

namespace AzureSQLWebAPIMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleModelsController : ControllerBase
    {
        private readonly ExampleModelService _service;

        public ExampleModelsController(ExampleModelService service)
        {
            _service = service;
        }

        // POST: api/ExampleModels
        [HttpPost]
        public async Task<ActionResult<ExampleModel>> PostExampleModel(ExampleModel model)
        {
            // Ensure the Id is set to 0 (or simply ignore it)
            // The database will auto-generate the Id value
            model.Id = 0;

            var createdModel = await _service.AddExampleModel(model);

            return CreatedAtAction(nameof(GetExampleModel), new { id = createdModel.Id }, createdModel);
        }

        // GET: api/ExampleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExampleModel>>> GetExampleModels()
        {
            return await _service.GetAllExampleModels();
        }

        // GET: api/ExampleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleModel>> GetExampleModel(int id)
        {
            var model = await _service.GetExampleModelById(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/ExampleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExampleModel(int id, ExampleModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var updatedModel = await _service.UpdateExampleModel(id, model);

            if (updatedModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        // DELETE: api/ExampleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExampleModel(int id)
        {
            var success = await _service.DeleteExampleModel(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

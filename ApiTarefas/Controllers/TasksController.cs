using ApiTarefas.Database;
using ApiTarefas.DTO;
using ApiTarefas.Models;
using ApiTarefas.Models.Errors;
using ApiTarefas.ModelViews;
using ApiTarefas.Services;
using ApiTarefas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using TaskModel = ApiTarefas.Models.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTarefas.controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class TasksController : ControllerBase {

        public TasksController(ITaskService service )
        {
			_service = service;  
        }

		private readonly ITaskService _service;

        //verb definition HTTP
        [HttpGet]
       public IActionResult Index(int page = 1) {
			var tasks = _service.GetTasks(page);

			return StatusCode(200, tasks);
		}

		[HttpPost]

		public IActionResult Create([FromBody] TaskDto taskDTO) {

			try {
				var task = _service.Include(taskDTO);

				return StatusCode(201, task);
			}
			catch (TaskError error) {

				return BadRequest(new ErrorView { Message = error.Message });
			}
		}
		[HttpPatch("{id}")]
		public IActionResult Update([FromRoute] int id, [FromBody] TaskDto taskDTO) {
			try {
				var taskdb = _service.Update(id,taskDTO);

				return StatusCode(200, taskDTO);
			}
			catch (TaskError error) {
				return BadRequest(new ErrorView { Message = error.Message });
			}
	

		}

		[HttpGet("{id}")]

		public IActionResult Show([FromRoute] int id) {

			try {
				var taskdb = _service.FindById(id);
				return StatusCode(200, taskdb);
			}
			catch (TaskError error) {
				return BadRequest(new ErrorView { Message = error.Message });
			}
		}

		[HttpDelete("{id}")]

		public IActionResult Delete([FromRoute] int id) {
			try {
				 _service.Delete(id);
				return StatusCode(204);
			}
			catch (TaskError error) {

				return BadRequest(new ErrorView { Message = error.Message });
			}
		}
	}
}

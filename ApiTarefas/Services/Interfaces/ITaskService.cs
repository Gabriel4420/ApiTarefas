using ApiTarefas.DTO;
using ApiTarefas.Models;
using Task = ApiTarefas.Models.Task;

namespace ApiTarefas.Services.Interfaces;
public interface ITaskService {
	List<Task> GetTasks(int page);
	
	Task Include(TaskDto taskDto);

	
	Task Update(int id, TaskDto taskDto);

	Task FindById(int id);

	void Delete(int id);
}

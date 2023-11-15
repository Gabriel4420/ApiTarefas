using ApiTarefas.Database;
using ApiTarefas.DTO;
using ApiTarefas.Models.Errors;
using ApiTarefas.Services.Interfaces;
using Task = ApiTarefas.Models.Task;

namespace ApiTarefas.Services;
public class TaskService : ITaskService {
    public TaskService(TasksContext db)
    {
        _db = db;
    }

    private readonly TasksContext _db;

    public List<Task> GetTasks(int page) {

		if(page < 1) page = 1;

		int limit = 10;
		int offset = (page - 1)* limit;


        return _db.tasks.Skip(offset).Take(limit).ToList();
    }

    public Task Include(TaskDto taskDto) {
		if (string.IsNullOrEmpty(taskDto.Title)) {
			throw new TaskError ("Title cannot be empty" );
		}
		var task = new Task { Title = taskDto.Title, Description = taskDto.Description, IsCompleted = taskDto.IsCompleted };
		_db.tasks.Add(task);
        _db.SaveChanges();
        return task;
    }

    public Task Update(int id, TaskDto taskDto) {

		if (string.IsNullOrEmpty(taskDto.Title)) {
			throw new TaskError("Title cannot be empty");
		}

		var taskDb = _db.tasks.FirstOrDefault(t => t.Id == id);

        if (taskDb == null) {
            throw new TaskError("Task not Found");
        }

        taskDb.Title = taskDto.Title;
        taskDb.Description = taskDto.Description;
        taskDb.IsCompleted = taskDto.IsCompleted;
        
        _db.tasks.Update(taskDb);
		_db.SaveChanges();
		return taskDb;
	}

	public Task FindById(int id) {

		var taskDb = _db.tasks.FirstOrDefault(t => t.Id == id);

		if (taskDb == null) {
			throw new TaskError("Task not Found");
		}

		
		return taskDb;
	}

	public void Delete(int id) {

		var taskDb = _db.tasks.FirstOrDefault(t => t.Id == id);

		if (taskDb == null) {
			throw new TaskError("Task not Found");
		}

		_db.tasks.Remove(taskDb);
		_db.SaveChanges();

	}

	
}

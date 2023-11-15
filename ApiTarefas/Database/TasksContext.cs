using ApiTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Task = ApiTarefas.Models.Task;

namespace ApiTarefas.Database;
public class TasksContext : DbContext {

#nullable disable
	public TasksContext( DbContextOptions<TasksContext> options): base(options) { }

	public DbSet<Task> tasks { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefas.Models;

[Table(name:"Tasks")]
public class Task {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = default!;
    
    [Column(TypeName = "text")]
    public string Description { get; set; } = default!;

    public bool IsCompleted { get; set; }
}

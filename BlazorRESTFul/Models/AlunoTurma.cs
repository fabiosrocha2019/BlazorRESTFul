using System.ComponentModel.DataAnnotations;

namespace BlazorRESTFul.Models
{
    public class AlunoTurma
    {
        [Required]
        public int IdAluno { get; set; }
        
        [Required]
        public int IdTurma { get; set; }

    }
}

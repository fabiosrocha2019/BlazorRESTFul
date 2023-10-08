using System.ComponentModel.DataAnnotations;

namespace BlazorRESTFul.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public int CursoId { get; set; }

        [Required]
        public string turma { get; set; }
        [Required]
        [Range(2023,9999)]
        public int Ano { get; set; }
    }
}

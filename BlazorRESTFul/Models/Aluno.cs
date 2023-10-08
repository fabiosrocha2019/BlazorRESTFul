using System.ComponentModel.DataAnnotations;

namespace BlazorRESTFul.Models
{
    public class Aluno
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}

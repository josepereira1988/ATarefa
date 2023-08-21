using System.ComponentModel.DataAnnotations;

namespace Dominio.Models
{
    public class ComentariosTarefaCreateDto
    {
        [Required]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "A Descrição pode ter mínimo {1} e máxima {2} de caracteres")]
        public string Comentario { get; set; }
    }
}

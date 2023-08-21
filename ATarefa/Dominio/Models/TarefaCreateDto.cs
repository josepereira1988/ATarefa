using Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Models
{
    public class TarefaCreateDto
    {
        public Status Status { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Título pode ter mínimo {1} e máxima {2} de caracteres")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "A Descrição pode ter mínimo {1} e máxima {2} de caracteres")]
        public string Descricao { get; set; }
        public List<ComentariosTarefaCreateDto> comentarios { get; set; }
    }
}

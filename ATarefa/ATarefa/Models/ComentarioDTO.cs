using Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace ATarefa.Models
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "A Descrição pode ter no máxima {2} de caracteres")]
        public string Comentario { get; set; }
    }
}

using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class ComentariosTarefa
    {
        public int Id { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "A Descrição pode ter mínimo {1} e máxima {2} de caracteres")]
        public string Comentario { get; set; }
        public DateTime DtCriacao { get; set; } = DateTime.Now;
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}

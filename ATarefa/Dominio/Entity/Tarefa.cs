using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Tarefa
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime DtCriacao { get; set; } = DateTime.Now;
        public DateTime? DtUpdate { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "Título pode ter mínimo {1} e máxima {2} de caracteres")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "A Descrição pode ter mínimo {1} e máxima {2} de caracteres")]
        public string Descricao { get; set; }
        public List<ComentariosTarefa> comentarios { get; set;}


    }
}

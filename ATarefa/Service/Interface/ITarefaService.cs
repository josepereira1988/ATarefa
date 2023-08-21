using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITarefaService
    {
        Task<bool> Add(Tarefa tarefa);
        Task<bool> AddComentario(ComentariosTarefa tarefa);
        Task<bool> Update(Tarefa tarefa);
        Task<bool> Remove(int Id);
        Task<List<Tarefa>> GetAll();
        Task<Tarefa> GetById(int Id);
    }
}

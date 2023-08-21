using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    public interface ITarefaPersist
    {
        Task<bool> Add<T>(T tarefa) where T : class;
        Task<bool> Update(Tarefa tarefa);
        Task<bool> Remove(int Id);
        Task<List<Tarefa>> GetAll();
        Task<Tarefa> GetById(int Id);
    }
}

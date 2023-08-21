using Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using Persistencia.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Persist
{
    public class TarefaPersist : ITarefaPersist
    {
        private MyContext _context;

        public TarefaPersist(MyContext context)
        {
            _context = context;
        }

        public async Task<bool> Add<T>(T tarefa) where T : class
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Add(tarefa);

                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public async Task<List<Tarefa>> GetAll()
        {
            return await _context.tarefas.Include(c => c.comentarios).ToListAsync();
        }

        public async Task<Tarefa> GetById(int Id)
        {
            return await _context.tarefas.Include(c => c.comentarios).FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task<bool> Remove(int Id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var tarefa = await _context.tarefas.FindAsync(Id);
                    if (tarefa == null)
                    {
                        return false; // O objeto não foi encontrado, não é possível remover
                    }

                    _context.tarefas.Remove(tarefa);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return true; // Remoção bem-sucedida
                }
                catch (Exception ex)
                {
                    throw ex; // Algum erro ocorreu durante a remoção
                }
            }

        }

        public async Task<bool> Update(Tarefa tarefa)
        {
            try
            {
                var tarefaExistente = await _context.tarefas.FindAsync(tarefa.Id);
                if (tarefaExistente == null)
                {
                    return false; // A tarefa não foi encontrada, não é possível atualizar
                }
                tarefaExistente.Titulo = tarefa.Titulo;
                tarefaExistente.Descricao = tarefa.Descricao;
                tarefaExistente.DtUpdate = DateTime.Now;
                _context.tarefas.Update(tarefaExistente);
                await _context.SaveChangesAsync();

                return true; // Atualização bem- sucedida
            }
            catch (Exception ex)
            {
                throw ex; // Algum erro ocorreu durante a atualização
            }
        }
    }
}


using Dominio.Entity;
using Persistencia.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaPersist _persist;
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        public TarefaService(ITarefaPersist persist)
        {
            _persist = persist;
        }

        public async Task<bool> Add(Tarefa tarefa)
        {
            try
            {
                if (await _persist.Add<Tarefa>(tarefa))
                {
                    tarefa.comentarios = new List<ComentariosTarefa>();
                    _tarefas.Add(tarefa);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Tarefa>> GetAll()
        {
            if (_tarefas.Count > 0)
            {
                return _tarefas;
            }
            else
            {
                _tarefas = await _persist.GetAll();
                return _tarefas.OrderBy(t => t.Id).ToList();
            }
        }

        public async Task<Tarefa> GetById(int Id)
        {
            var result = _tarefas.Where(t => t.Id == Id).FirstOrDefault();
            if (result == null)
            {
                return await _persist.GetById(Id);
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> Remove(int Id)
        {
            try
            {
                if (await _persist.Remove(Id))
                {
                    var remove = _tarefas.Where(t => t.Id == Id).FirstOrDefault();
                    if (remove == null)
                    {
                        return true;
                    }

                    _tarefas.Remove(remove);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Update(Tarefa tarefa)
        {
            try
            {
                if (await _persist.Update(tarefa))
                {

                    var resul = _tarefas.Where(c => c.Id == tarefa.Id).FirstOrDefault();
                    if(resul == null)
                    {
                        _tarefas.Add(tarefa);
                    }
                    else
                    {
                        _tarefas.Remove(resul);
                        resul.Titulo = tarefa.Titulo;
                        resul.Descricao = tarefa.Descricao;
                        _tarefas.Add(resul);
                    }

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> AddComentario(ComentariosTarefa comentario)
        {
            try
            {
                if (await _persist.Add<ComentariosTarefa>(comentario))
                {
                    var result = _tarefas.Where(e => e.Id == comentario.TarefaId).FirstOrDefault();
                    if (result == null)
                    {
                        _tarefas.Add(await _persist.GetById(comentario.TarefaId));
                    }
                    else
                    {
                        _tarefas.Remove(result);
                        result.comentarios.Add(comentario);
                        _tarefas.Add(result);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

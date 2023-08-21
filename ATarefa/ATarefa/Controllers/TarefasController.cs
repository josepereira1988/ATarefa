using ATarefa.Models;
using Dominio.Entity;
using Dominio.Enum;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace ATarefa.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaService _service;

        public TarefasController(ITarefaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _service.GetAll();


            return View(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> CriarTarefa()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarTarefa(Tarefa tarefa)
        {
            try
            {
                if (tarefa == null)
                {
                    return BadRequest();
                }
                if (await _service.Add(tarefa))
                {
                    return RedirectToAction("Index");
                }
                /// Mensagem de erro
                ModelState.AddModelError(string.Empty, "Erro ao adiniar tarefa");
                return View(tarefa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Detalhe(int Id)
        {
            var result = await _service.GetById(Id);
            if(result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarTarefa(int Id)
        {
            var result = await _service.GetById(Id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AtualizarTarefa(Tarefa tarefa)
        {
            try
            {
                if (tarefa == null)
                {
                    return BadRequest();
                }
                if (await _service.Update(tarefa))
                {
                    return RedirectToAction("Index");
                }
                /// Mensagem de erro
                ModelState.AddModelError(string.Empty, "Erro ao adiniar tarefa");
                return View(tarefa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Comantario(int Id)
        {
            var result = await _service.GetById(Id);
            if(result == null)
            {
                NotFound();
            }
            return View(new ComentarioDTO { Id = Id,Status = result.Status });
        }
        [HttpPost]
        public async Task<IActionResult> Comantario(ComentarioDTO comentarios)
        {
            try
            {
                if (comentarios == null)
                {
                    return BadRequest();
                }
                if (await _service.AddComentario(new ComentariosTarefa
                {
                    TarefaId = comentarios.Id,
                    Comentario = comentarios.Comentario
                }))
                {
                    var result = await _service.GetById(comentarios.Id);
                    if (result.Status != comentarios.Status)
                    {
                        result.Status = comentarios.Status;
                        if(!await _service.Update(result))
                        {
                            return BadRequest();
                        }
                    }
                    return RedirectToAction("Detalhe",new { Id = comentarios.Id });
                }
                /// Mensagem de erro
                ModelState.AddModelError(string.Empty, "Erro ao adiniar tarefa");
                return View(comentarios);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _service.GetById(Id);
            if (result == null)
            {
                NotFound();
            }
            return View(result);
        }
        [HttpPost, ActionName("DeletarConfirmar")]
        public async Task<IActionResult> DeletarConfirmar(int Id)
        {
            try
            {
                if(await _service.Remove(Id))
                {
                    return RedirectToAction("Index");
                }
                /// Mensagem de erro
                ModelState.AddModelError(string.Empty, "Erro ao excluir a tarefa");
                return View(_service.GetById(Id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

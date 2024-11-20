using GestaoFacil.DataContexts;
using GestaoFacil.DTOs;
using GestaoFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoFacil.Controllers
{
    [Route("servidor")]
    [ApiController]
    public class TarefaController(AppDbContext context) : Controller
    {

        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaServidores = await _context.Servidores.ToListAsync();

                return Ok(listaServidores);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try
            {
                var servidor = await _context.Servidores.Where(s => s.Id == id).FirstOrDefaultAsync();

                if(servidor == null)
                {
                    return NotFound($"Servidor #{id} não encontrado");
                }

                return Ok(servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServidorDTO item)
        {
             try
            {
                var servidor = new Servidor()
                {
                    Nome = item.nome,
                    Cpf = item.cpf,
                    SIAPE = item.SIAPE,
                };

                await _context.Servidores.AddAsync(servidor);
                await _context.SaveChangesAsync();

                return Created("", servidor);
            }
            catch (Exception)
            {
                return Problem($"Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ServidorDTO item)
        {
             try
            {
                var servidor = await _context.Servidores.FindAsync(id);
                if(servidor is null)
                {
                    return NotFound();
                }

                servidor.Nome = item.nome;
                servidor.Cpf = item.cpf;
                servidor.SIAPE = item.SIAPE;

                _context.Servidores.Update(servidor);
                await _context.SaveChangesAsync();

                return Ok(servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                var servidor = await _context.Servidores.FindAsync(id);

                if (servidor is null)
                {
                    return NotFound();
                }

                _context.Servidores.Remove(servidor);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        
    }
}
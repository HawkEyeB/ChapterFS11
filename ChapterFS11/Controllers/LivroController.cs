using ChapterFS11.Models;
using ChapterFS11.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ChapterFS11.Controllers
{
    [Produces("application/json")] //saida de dados em json
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LivroController : ControllerBase
    {
        private readonly LivroRepository? _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {

                Livro livroBuscado = _livroRepository.BuscarPorId(id);

                if (livroBuscado == null)
                {
                    return NotFound();
                }

                return Ok(livroBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [Authorize(Roles = "1")]
        [HttpPost]

        public IActionResult Cadastrar(Livro l)
        {
            try
            {
                _livroRepository.Cadastrar(l);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return Ok("Livro removido com sucesso");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("id")]
        public IActionResult Alterar(int id, Livro l)
        {
            try
            {
                _livroRepository.Alterar(id, l);
                return StatusCode(200);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}

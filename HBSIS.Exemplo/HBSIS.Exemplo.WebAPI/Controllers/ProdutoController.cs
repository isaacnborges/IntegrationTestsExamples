using HBSIS.Exemplo.Dominio.Comandos;
using HBSIS.Exemplo.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HBSIS.Exemplo.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoServivo;

        public ProdutoController(IProdutoServico produtoServivo)
        {
            _produtoServivo = produtoServivo;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ComandoInserirProduto comando)
        {
            try
            {               
                return new ObjectResult(_produtoServivo.Inserir(comando));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ComandoAtualizarProduto comando)
        {
            try
            {                
                return new ObjectResult(_produtoServivo.Atualizar(comando));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("{id}")]
        public IActionResult Remover([FromRoute] Guid id)
        {
            try
            {
                _produtoServivo.Remover(id);

                return new ObjectResult(true);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("{id}")]
        public IActionResult Obter([FromRoute] Guid id)
        {
            try
            {
                return new ObjectResult(_produtoServivo.Obter(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                return new ObjectResult(_produtoServivo.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

using FiapSmartCityWebAPI.Models;
using FiapSmartCityWebAPI.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FiapSmartCityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private readonly TipoProdutoRepository tipoProdutoRepository;

        public TipoProdutoController()
        {
            tipoProdutoRepository = new TipoProdutoRepository();
        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoProduto> Get([FromRoute] int id)
        {
            try
            {
                TipoProduto TipoProduto = tipoProdutoRepository.Consultar(id);
                return Ok(TipoProduto);
            } catch (KeyNotFoundException) {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<IList<TipoProduto>> Get()
        {
            try
            {
                var tiposProdutos = tipoProdutoRepository.Listar();
                return Ok(tiposProdutos);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult<TipoProduto> Post([FromBody] TipoProduto tipoProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                tipoProdutoRepository.Inserir(tipoProduto);
                tipoProduto.IdTipo = new Random().Next();

                var location = new Uri(Request.GetEncodedUrl() + "/" + tipoProduto.IdTipo);

                return Created(location, tipoProduto);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível o tipo de produto. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<TipoProduto> Put([FromRoute] int id, [FromBody] TipoProduto tipoProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoProduto.IdTipo != id)
            {
                return NotFound();
            }

            try
            {
                tipoProdutoRepository.Alterar(tipoProduto);

                return Ok(tipoProduto);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o tipo de produto. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<TipoProduto> Delete([FromRoute] int id)
        {
            tipoProdutoRepository.Excluir(id);
            return Ok();
        }


    }
}

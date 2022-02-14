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
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController()
        {
            produtoRepository = new ProdutoRepository();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get([FromRoute] int id)
        {
            try
            {
                Produto produto = produtoRepository.Consultar(id);
                return Ok(produto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<IList<TipoProduto>> Get()
        {
            try
            {
                var produtos = produtoRepository.Listar();
                return Ok(produtos);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult<TipoProduto> Post([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                produtoRepository.Inserir(produto);
                produto.IdProduto = new Random().Next();

                var location = new Uri(Request.GetEncodedUrl() + "/" + produto.IdProduto);

                return Created(location, produto);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível o produto. Detalhes: {error.Message}" });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<TipoProduto> Put([FromRoute] int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (produto.IdProduto != id)
            {
                return NotFound();
            }

            try
            {
                produtoRepository.Alterar(produto);

                return Ok(produto);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o produto. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<TipoProduto> Delete([FromRoute] int id)
        {
            produtoRepository.Excluir(id);
            return Ok();
        }
    }
}

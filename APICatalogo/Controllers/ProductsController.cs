using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var produtos = _repository.GetAll();
            if (produtos is null) return NotFound();
            return Ok(produtos);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id:int:min(1)}", Name="GetProduto")]
        public ActionResult<Product> Get(int id)
        {
            var produto = _repository.GetByIdy(id);
            if (produto is null) return NotFound();
            return Ok(produto);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult<Product> Post(Product produto)
        {
            if (produto is null) return BadRequest();
            _repository.Create(produto);    
            return new CreatedAtRouteResult("GetProduto", new { id = produto.Id }, produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Product> Put(int id, Product produto)
        {
            if(id != produto.Id) return BadRequest();
            _repository.Update(produto);
            return Ok(produto);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var produto = _repository.Delete(id);
            return Ok();
        }
    }
}

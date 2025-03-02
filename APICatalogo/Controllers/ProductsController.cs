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


        public ProductsController( IProductRepository repositoryProduct)
        {
            _repository = repositoryProduct;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _repository.GetAll();
            if (products is null) return NotFound();
            return Ok(products);
        }

        [HttpGet("ProductsByCategoryId")]
        public ActionResult<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            var products = _repository.GetProductsByCategory(id);
            if (products is null) return NotFound();
            return Ok(products);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id:int:min(1)}", Name="GetProduto")]
        public ActionResult<Product> Get(int id)
        {
            var product = _repository.Get(p => p.Id == id);
            if (product is null) return NotFound();
            return Ok(product);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if (product is null) return BadRequest();
            _repository.Create(product);    
            return new CreatedAtRouteResult("GetProduto", new { id = product.Id }, product);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Product> Put(int id, Product product)
        {
            if(id != product.Id) return BadRequest();
            _repository.Update(product);
            return Ok(product);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var product = _repository.Get(p => p.Id == id);
            if(product is null) return NotFound();
            _repository.Delete(product);
            return Ok();
        }
    }
}

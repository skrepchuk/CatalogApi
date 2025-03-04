using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.DTOs;
using APICatalogo.DTOs.Mappings;
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
        private readonly IUnitOfWork _uow;

        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

                // GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> Get()
        {
            var products = _uow.ProductRepository.GetAll();
            if (products is null) return NotFound();
            return Ok(products);
        }

        [HttpGet("ProductsByCategoryId")]
        public ActionResult<IEnumerable<ProductDTO>> GetProductsByCategory(int id)
        {
            var products = _uow.ProductRepository.GetProductsByCategory(id);
            if (products is null) return NotFound();            
            return Ok(ProductDTOMappingExtensions.ToProductDTOList(products));
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id:int:min(1)}", Name="GetProduto")]
        public ActionResult<ProductDTO> Get(int id)
        {
            var product = _uow.ProductRepository.Get(p => p.Id == id);
            if (product is null) return NotFound();
            return Ok(ProductDTOMappingExtensions.ToProductDTO(product));
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult<ProductDTO> Post(ProductDTO product)
        {
            if (product is null) return BadRequest();
            if (ProductDTOMappingExtensions.ToProductDomain(product) is null) 
            {
                return BadRequest();
            }
            else
            {
                _uow.ProductRepository.Create(ProductDTOMappingExtensions.ToProductDomain(product));
                _uow.Commit();
                return new CreatedAtRouteResult("GetProduto", new { id = product.Id });
            }
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<ProductDTO> Put(int id, ProductDTO product)
        {
            if (ProductDTOMappingExtensions.ToProductDomain(product) is null)
            {
                return BadRequest();
            }
            else
            {
                _uow.ProductRepository.Update(ProductDTOMappingExtensions.ToProductDomain(product));
                _uow.Commit();
                return Ok(product);
            }
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var product = _uow.ProductRepository.Get(p => p.Id == id);
            if(product is null) return NotFound();
            _uow.ProductRepository.Delete(product);
            _uow.Commit();
            return Ok();
        }
    }
}

using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APICatalogContext _context;

        public ProdutosController(APICatalogContext context)
        {
            _context = context;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();
            if (produtos is null) return NotFound();
            return Ok(produtos);
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id:int:min(1)}", Name="GetProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (produto is null) return NotFound();
            return Ok(produto);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public ActionResult<Produto> Post(Produto produto)
        {
            if (produto is null) return BadRequest();
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetProduto", new { id = produto.Id }, produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Produto> Put(int id, Produto produto)
        {
            if(id != produto.Id) return BadRequest();
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto is null) return NotFound();
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok();
        }
    }
}

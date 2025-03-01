using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogContext _context;

        public CategoriasController(APICatalogContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.AsNoTracking().ToList();
            if (categorias is null) return NotFound();
            return Ok(categorias);
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var  categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (categoria is null) return NotFound();
            return Ok(categoria);
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos() 
        {
            return _context.Categorias.Include(p => p.Produtos).AsNoTracking().ToList();
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            if (categoria is null) return BadRequest();
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Categoria> Put(int id, Categoria categoria)
        {
            if (id != categoria.Id) return BadRequest();
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria is null) return NotFound();
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok();
        }
    }
}

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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieRepository _repository;

        public CategoriesController(ICategorieRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categorias = _repository.GetAll();
            if (categorias is null) return NotFound();
            return Ok(categorias);
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetCategoria")]
        public ActionResult<Category> Get(int id)
        {           
            var  categoria = _repository.GetByIdy(id);
            if (categoria is null) return NotFound();
            return Ok(categoria);
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public ActionResult<Category> Post(Category categoria)
        {
            if (categoria is null) return BadRequest();
            _repository.Create(categoria);
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Category> Put(int id, Category categoria)
        {
            if (id != categoria.Id) return BadRequest();
            _repository.Update(categoria);
            return Ok(categoria);
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            var category = _repository.Delete(id);
            return Ok();
        }
    }
}

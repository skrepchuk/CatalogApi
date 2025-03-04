using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.DTOs;
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
        private readonly IUnitOfWork _uow;

        public CategoriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/<categoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            var categoriesDomain = _uow.CategorieRepository.GetAll();
            if (categoriesDomain is null) return NotFound();
            var categoriesDto = new List<CategoryDTO>();
            foreach (var category in categoriesDomain) {
                var categoryDTO = new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImageUrl = category.ImageUrl
                };
                categoriesDto.Add(categoryDTO);
            }            
            return Ok(categoriesDto);
        }

        // GET api/<categoriesController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetCategory")]
        public ActionResult<CategoryDTO> Get(int id)
        {           
            var  category = _uow.CategorieRepository.Get(c => c.Id == id);
            if (category is null) return NotFound();
            var categoryDTO = new CategoryDTO 
            { 
                Id = id,
                Name = category.Name,
                ImageUrl = category.ImageUrl   
            };
            return Ok(categoryDTO);
        }

        // POST api/<categoriesController>
        [HttpPost]
        public ActionResult<CategoryDTO> Post(CategoryDTO category)
        {
            if (category is null) return BadRequest();
            var categoryDomain = new Category 
            { 
                Id = category.Id, 
                Name = category.Name, 
                ImageUrl =category.ImageUrl  
            };
            _uow.CategorieRepository.Create(categoryDomain);
            _uow.Commit();
            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        // PUT api/<categoriesController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<CategoryDTO> Put(int id, CategoryDTO category)
        {
            if (id != category.Id) return BadRequest();
            var categoryDomain = new Category
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl
            };
            _uow.CategorieRepository.Update(categoryDomain);
            _uow.Commit();
            return Ok(category);
        }

        // DELETE api/<categoriesController>/5
        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<CategoryDTO> Delete(int id)
        {
            var category = _uow.CategorieRepository.Get(c => c.Id == id);
            if (category is null) return NotFound();
            _uow.CategorieRepository.Delete(category);
            _uow.Commit();
            return Ok();
        }
    }
}

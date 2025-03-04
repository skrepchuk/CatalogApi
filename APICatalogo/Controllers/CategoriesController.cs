using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.DTOs;
using APICatalogo.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/<categoriesController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            var categoriesDomain = _uow.CategorieRepository.GetAllAsync();
            if (categoriesDomain is null) return NotFound();
            var categoriesDto = _mapper.Map <IEnumerable <CategoryDTO>> (categoriesDomain);
            return Ok(categoriesDto);
        }

        // GET api/<categoriesController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetCategory")]
        public ActionResult<CategoryDTO> Get(int id)
        {           
            var  category = _uow.CategorieRepository.GetAsync(c => c.Id == id);
            if (category is null) return NotFound();
            var categoriesDto = _mapper.Map<CategoryDTO>(category);
            return Ok(categoriesDto);
        }

        // POST api/<categoriesController>
        [HttpPost]
        public ActionResult<CategoryDTO> Post(CategoryDTO category)
        {
            if (category is null) return BadRequest();
            var categoryDomain = _mapper.Map<Category>(category);
            _uow.CategorieRepository.Create(categoryDomain);
            _uow.CommitAsync();
            return categoryDTO(categoryDomain);
        }

        // PUT api/<categoriesController>/5
        [HttpPut("{id:int:min(1)}")]
        public ActionResult<CategoryDTO> Put(int id, CategoryDTO category)
        {
            if (id != category.Id) return BadRequest();
            var categoryDomain = _mapper.Map<Category>(category);
            _uow.CategorieRepository.Update(categoryDomain);
            _uow.CommitAsync();
            return categoryDTO(categoryDomain);
        }

        private ActionResult<CategoryDTO> categoryDTO(Category categoryDomain)
        {
            var createdCategory = _uow.CategorieRepository.GetAsync(c => c.Id == categoryDomain.Id);
            var createdCategoryDTO = _mapper.Map<CategoryDTO>(createdCategory);
            return Ok(createdCategoryDTO);
        }

        // DELETE api/<categoriesController>/5
        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int? id)
        {
            if (id.HasValue)
            {
                var category = await _uow.CategorieRepository.GetAsync(c => c.Id == id);
                if (category is null) return NotFound();
                _uow.CategorieRepository.Delete(category);
                await _uow.CommitAsync();
                var deletedCategory = _mapper.Map<CategoryDTO>(category);
                return Ok(deletedCategory);
            }
            else
            {
                return BadRequest(); 
            }
        }
    }
}

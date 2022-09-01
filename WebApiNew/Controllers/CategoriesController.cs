using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApiNew.Data;
using WebApiNew.Dto;

namespace WebApiNew.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ProductContext _context;
        private object[] id;
        private Product removedEntity;

        public CategoriesController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id)
        {
            var data = _context.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Categories.Include(x => x.Products).ToList();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert(CategoryDto category)
        {
            _context.Categories.Add(new Category()
            {
                Name = category.Name,
                Stock = category.Stock,
                Price = category.Price,
                CreatedDate = category.CreatedDate,
                ImagePath = category.ImagePath
            });
            _context.SaveChanges();

            return Created("", $"{category.Name} eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleteEntity = _context.Categories.Find(id);
            if (deleteEntity == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(deleteEntity);
            _context.SaveChanges();
            return Ok($"{deleteEntity.Name} silindi.");
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto category)
        {
            var checkProduct = _context.Categories.Any(c => c.Id == category.Id);
            if (checkProduct is false)
            {
                return NotFound("Bulunamadı.");
            }
            _context.Categories.Update(new Category()
            {
                Id = category.Id,
                Name = category.Name,
                Stock = category.Stock,
                Price = category.Price,
                CreatedDate = category.CreatedDate,
                ImagePath = category.ImagePath
            });
            _context.SaveChanges();
            return NoContent();
        }
    }
}

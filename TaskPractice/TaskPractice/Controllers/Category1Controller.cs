using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskPractice.Data.dto;
using TaskPractice.Data.Model;
using TaskPractice.Services;

namespace TaskPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category1Controller : ControllerBase
    {
        private readonly ICategory category;

        public Category1Controller(ICategory category)
        {
            this.category = category;
        }
        [HttpPost]
        public ActionResult AddCategory(dto_Category categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            category.Add(categoryDto);
            return Ok("Category Added Successfully");
        }

    }
}

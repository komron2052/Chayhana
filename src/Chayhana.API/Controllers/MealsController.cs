using Chayhana.Domain.Configurations;
using Chayhana.Service.DTOs;
using Chayhana.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chayhana.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealService mealMervice;

        public MealsController(IMealService mealMervice)
        {
            this.mealMervice = mealMervice;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(MealForCreationDto dto) =>
            Ok(await mealMervice.AddAsync(dto));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute]int id) =>
            Ok(await mealMervice.RetrieveByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, string searchString) =>
            Ok(await mealMervice.RetrieveAllAsync(@params, searchString));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) =>
            Ok(await mealMervice.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, MealForCreationDto dto) =>
            Ok(await mealMervice.ModifyAsync(id, dto));
    }
}

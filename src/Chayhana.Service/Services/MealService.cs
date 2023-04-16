using AutoMapper;
using Chayhana.Data.IRepositories;
using Chayhana.Domain.Configurations;
using Chayhana.Domain.Entities;
using Chayhana.Service.DTOs;
using Chayhana.Service.Exeptions;
using Chayhana.Service.Extensions;
using Chayhana.Service.Interfaces;

namespace Chayhana.Service.Services;

public class MealService : IMealService
{
    private readonly IRepository<Meal> mealRepository;
    private readonly IMapper mapper;
    public MealService(IRepository<Meal> mealRepository, IMapper mapper)
    {
        this.mealRepository = mealRepository;
        this.mapper = mapper;
    }

    public async Task<MealForResultDto> AddAsync(MealForCreationDto dto)
    {
        var meal = await this.mealRepository.SelectAsync(m => m.Name.ToLower() == dto.Name.ToLower());
        if (meal != null)
            throw new CustomExeption(400, "Meal already exists");

        var mappedMeal = this.mapper.Map<Meal>(dto);
        mappedMeal.CreatedAt = DateTime.UtcNow;
        var addedMeal = await this.mealRepository.InsertAsync(mappedMeal);

        await this.mealRepository.SaveAsync();

        return this.mapper.Map<MealForResultDto>(addedMeal);

    }

    public async Task<MealForResultDto> ModifyAsync(int id, MealForCreationDto dto)
    {
        var meal = await this.mealRepository.SelectAsync(m => m.Id == id);
        if (meal == null)
            throw new CustomExeption(404, "Not found");

        var mappedMeal = this.mapper.Map(dto, meal);
        mappedMeal.UpdatedAt = DateTime.UtcNow;

        await this.mealRepository.SaveAsync();

        return this.mapper.Map<MealForResultDto>(mappedMeal);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var meal = await this.mealRepository.SelectAsync(m => m.Id == id);
        if (meal == null)
            throw new CustomExeption(404, "Not found");

        await this.mealRepository.DeleteAsync(m => m.Id == id);

        return true;
    }

    public async Task<IEnumerable<MealForResultDto>> RetrieveAllAsync(PaginationParams @params, string searchString)
    {
        var meals = this.mealRepository.SelectAll();

        meals = !string.IsNullOrEmpty(searchString) ? meals.Where(m => m.Name.Contains(searchString) ||
        m.Description.Contains(searchString)).ToPagedList(@params) : meals.ToPagedList(@params);

        return this.mapper.Map<IEnumerable<MealForResultDto>>(meals.ToList());
    }

    public async Task<MealForResultDto> RetrieveByIdAsync(long id)
    {
        var meal = await this.mealRepository.SelectAsync(m => m.Id == id);
        if (meal == null)
            throw new CustomExeption(404, "Not found");

        return this.mapper.Map<MealForResultDto>(meal);
    }
}

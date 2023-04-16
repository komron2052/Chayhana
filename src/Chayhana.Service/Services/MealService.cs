using AutoMapper;
using Chayhana.Data.IRepositories;
using Chayhana.Domain.Configurations;
using Chayhana.Domain.Entities;
using Chayhana.Service.DTOs;
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

    public async Task<MealForResultDto> AddAsync(MealForCreationDto result)
    {
        throw new NotImplementedException();
    }

    public Task<MealForResultDto> ModifyAsync(int id, MealForCreationDto result)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MealForResultDto>> RetrieveAllAsync(PaginationParams @params, string searchString)
    {
        throw new NotImplementedException();
    }

    public Task<MealForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}

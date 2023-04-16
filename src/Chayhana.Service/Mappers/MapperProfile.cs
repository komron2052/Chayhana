using AutoMapper;
using Chayhana.Domain.Entities;
using Chayhana.Service.DTOs;

namespace Chayhana.Service.Mappers;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<MealForCreationDto, Meal>().ReverseMap();
		CreateMap<MealForResultDto, Meal>().ReverseMap();
		

		CreateMap<OrderForCreationDto, Order>().ReverseMap();
		CreateMap<OrderForResultDto, Order>().ReverseMap();
	}
}

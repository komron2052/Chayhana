using Chayhana.Domain.Entities;
using Chayhana.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Chayhana.Data.DbContexts;

public class ChayhanaDbContext : DbContext
{
	public ChayhanaDbContext(DbContextOptions<ChayhanaDbContext> options)
		: base(options)
	{

	}

	public DbSet<Meal> Meals { get; set; }	
	public DbSet<SoldMeal> SoldMeals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<SoldMeal>()
			.HasOne(m => m.Meal)
			.WithMany(s => s.SoldMeals)
			.HasForeignKey(m => m.MealId)
			.OnDelete(DeleteBehavior.NoAction);

		modelBuilder.Entity<Meal>().HasData(
			new Meal { Id = 1, Name = "Osh", Description = "Choyxona", Price = 35000, TotalAmount = 25, TotalSoldAmount = 0, ToTalRemainingAmount = 25, TotalMoneyOfSoldMeal = 0, Type = CategoryType.Milliy, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
			new Meal { Id = 2, Name = "Lagmon", Description = "Suyuq", Price = 20000, TotalAmount = 35, TotalSoldAmount = 0, ToTalRemainingAmount = 35, TotalMoneyOfSoldMeal = 0, Type = CategoryType.Milliy, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
			new Meal { Id = 3, Name = "Kimchi", Description = "Achchiq", Price = 22000, TotalAmount = 22, TotalSoldAmount = 0, ToTalRemainingAmount = 22, TotalMoneyOfSoldMeal = 0, Type = CategoryType.Milliy, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
			new Meal { Id = 4, Name = "Kabob", Description = "Gijduvon", Price = 20000, TotalAmount = 20, TotalSoldAmount = 0, ToTalRemainingAmount = 20, TotalMoneyOfSoldMeal = 0, Type = CategoryType.Milliy, CreatedAt = DateTime.UtcNow, UpdatedAt = null },
			new Meal { Id = 5, Name = "Shurva", Description = "Tovuqli", Price = 18000, TotalAmount = 40, TotalSoldAmount = 0, ToTalRemainingAmount = 40, TotalMoneyOfSoldMeal = 0, Type = CategoryType.Milliy, CreatedAt = DateTime.UtcNow, UpdatedAt = null }
			);
    }
}

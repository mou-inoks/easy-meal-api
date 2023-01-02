using System;
using Microsoft.EntityFrameworkCore;
using easy_meal_api.Models;
namespace easy_meal_api.Data
{
	public class ApiContext : DbContext
	{

		public ApiContext(DbContextOptions<ApiContext> options) : base(options)
		{

		}
		public DbSet<AlimentDao> Aliment { get; set; }
		public DbSet<TypeDao> Type { get; set; }
		public DbSet<RepasDao> Repas { get; set; }
	}
}


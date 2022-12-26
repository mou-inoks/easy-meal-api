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
		public DbSet<AlimentDao> Aliments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localhost);Database=mysql;Integrated Security: True;");
			base.OnConfiguring(optionsBuilder);
		}

    }
}


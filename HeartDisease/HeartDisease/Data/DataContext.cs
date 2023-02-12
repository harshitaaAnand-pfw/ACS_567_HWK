using System;
using HeartDisease.Models;
using Microsoft.EntityFrameworkCore;
namespace HeartDisease.Data
{
	public class DataContext : DbContext 
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Heart> Heart { get; set; }
		
	}
}


using System;
using HeartDisease.Data;
using HeartDisease.Models;
namespace HeartDisease
{
	public class Seed
	{
		private readonly DataContext dataContext;

		public Seed(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		public void SeedDataContext()
		{
			if (!dataContext.Heart.Any())
			{
				List<Heart> hearts = new()
				{
					new Heart { Id = 1, Description = "Prone to Heart disease", IsCompleted = false}
				};

				dataContext.Heart.AddRange(hearts);
				dataContext.SaveChanges();
			}
		}
	}
}


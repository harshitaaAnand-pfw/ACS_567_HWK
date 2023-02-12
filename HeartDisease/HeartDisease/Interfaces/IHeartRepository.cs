using System;
using HeartDisease.Models;
namespace HeartDisease.Interfaces
{
	public interface IHeartRepository
	{
		ICollection<Heart> GetHearts();

		Heart GetHeart(int id);

		bool HeartExists(int id);

		bool CreateHeart(Heart heart);

        bool UpdateHeart(Heart heart);

        bool DeleteHeart(Heart heart);

		bool Save();

		string GetHeartsAnalysis(int age);


    }
}


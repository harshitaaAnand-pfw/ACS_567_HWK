using System;
using HeartDisease.Models;
namespace HeartDisease.Interfaces
{
	public interface IHeartRepository
	{
        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns>get all data</returns>

        ICollection<Heart> GetHearts();

        /// <summary>
        /// get the data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data by id</returns>
        Heart GetHeart(int id);

		bool HeartExists(int id);

        /// <summary>
        /// add the data
        /// </summary>
        /// <param name="heart"></param>
        /// <returns>new value</returns>

        bool CreateHeart(Heart heart);

        /// <summary>
        /// update the data
        /// </summary>
        /// <param name="heart"></param>
        /// <param name="updated"></param>
        /// <returns>updated value</returns>

        bool UpdateHeart(Heart heart);

        /// <summary>
        /// delete the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null</returns>

        bool DeleteHeart(int id);

        /// <summary>
        /// Save the data in database
        /// </summary>
        /// <returns></returns>

        bool Save();

        /// <summary>
        /// analysis of the data
        /// </summary>
        /// <returns>analyse all data</returns>
        string GetHeartsAnalysis(int age);


    }
}


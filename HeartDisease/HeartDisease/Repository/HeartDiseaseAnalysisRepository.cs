using System;
using HeartDisease.Interfaces;
using HeartDisease.Models;
using HeartDisease.Data;

namespace HeartDisease
{
    public class HeartDiseaseAnalysisRepository : IHeartRepository
    {
        private DataContext _context;

        public HeartDiseaseAnalysisRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns>get all data</returns>
        public ICollection<Heart> GetHearts()
        {
            return _context.Heart.ToList();
        }
        /// <summary>
        /// get the data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data by id</returns>
        public Heart GetHeart(int id)
        {
            return _context.Heart.Where(hearts => hearts.Id == id).FirstOrDefault();
        }

        public bool HeartExists(int id)
        {
            return _context.Heart.Any(hearts => hearts.Id == id);
        }

        /// <summary>
        /// add the data
        /// </summary>
        /// <param name="heart"></param>
        /// <returns>new value</returns>
        public bool CreateHeart(Heart heart)
        {
            _context.Add(heart);
            return Save();
        }

        /// <summary>
        /// update the data
        /// </summary>
        /// <param name="heart"></param>
        /// <param name="updated"></param>
        /// <returns>updated value</returns>
        public bool UpdateHeart(Heart heart)
        {
            _context.Update(heart);
            return Save();
        }

        /// <summary>
        /// delete the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null</returns>
        public bool DeleteHeart(int id)
        {
            var items = _context.Heart.Where(item => item.Id == id);
            foreach (var item in items)
            {
                _context.Remove(item);
            }
            return Save();
        }

        /// <summary>
        /// Save the data in database
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }
        
        
        
        /// <summary>
        /// analysis of the data
        /// </summary>
        /// <returns>analyse all data</returns>
        public string GetHeartsAnalysis(int age)

        {

            if (age >= 0 && age <= 18)
            {
                //  Console.WriteLine("You are very less likely prone to a heart disease, still stay active and healthy");
                return "You are very less likely prone to a heart disease, still stay active and healthy";


            }
            else if (age > 18 && age <= 45)
            {
                //  Console.WriteLine("You may be prone to heart disease if you have a unhealthy lifestyle, Please take regular medical checkups to prevent it ");
                return "You may be prone to heart disease if you have a unhealthy lifestyle, Please take regular medical checkups to prevent it ";


            }
            else
            {
                //   Console.WriteLine("You are more likeley prone to heart disease, have regular health checkups and have a healthy lifestyle ");
                return "You are more likeley prone to heart disease, have regular health checkups and have a healthy lifestyle ";


            }


        }
    }
}


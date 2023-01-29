using System;
namespace HeartDisease
{
    public class HeartDiseaseAnalysisRepository
    {
        private static HeartDiseaseAnalysisRepository instance;
        private List<HeartDiseaseAnalysis> hearts;

        private HeartDiseaseAnalysisRepository()
        {
            hearts = new();
            hearts.Add(new HeartDiseaseAnalysis("add data"));
        }

        public static HeartDiseaseAnalysisRepository getInstance()
        {
            if (instance == null)
            {
                instance = new();
            }
            return instance;
        }
        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns>get all data</returns>
        public List<HeartDiseaseAnalysis> getHearts()
        {
            return hearts;
        }
        /// <summary>
        /// get the data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data by id</returns>
        public HeartDiseaseAnalysis GetHeart(int id)
        {
            HeartDiseaseAnalysis heart = null;

            foreach (HeartDiseaseAnalysis h in hearts)
            {
                if (id == h.Id)
                {
                    heart = h;
                    break;

                }
            }
            return heart;
        }
        /// <summary>
        /// add the data
        /// </summary>
        /// <param name="heart"></param>
        /// <returns>new value</returns>
        public bool addHeart(HeartDiseaseAnalysis heart)
        {
            bool isAdded = true;

            foreach (HeartDiseaseAnalysis h in hearts)
            {
                if (h.Id == heart.Id)
                {
                    isAdded = false;
                    break;
                }
            }
            if (isAdded)
            {
                hearts.Add(heart);
            }
            return isAdded;
        }
        /// <summary>
        /// update the data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updated"></param>
        /// <returns>updated value</returns>
        public bool editHeart(int id, HeartDiseaseAnalysis updated)
        {
            bool isEdited = false;

            foreach (HeartDiseaseAnalysis h in hearts)
            {
                if (h.Id == id)
                {
                    h.Description = updated.Description;
                    h.IsCompleted = updated.IsCompleted;
                    isEdited = true;
                    break;

                }
            }

            return isEdited;
        }
        /// <summary>
        /// delete the data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null</returns>
        public bool deleteHeart(int id)
        {
            HeartDiseaseAnalysis delete = null;

            foreach (HeartDiseaseAnalysis h in hearts)
            {
                if (id == h.Id)
                {
                    delete = h;
                    break;
                }
            }

            if (delete != null)
            {
                hearts.Remove(delete);
            }

            return delete == null;
        }

        /// <summary>
        /// analysis of the data
        /// </summary>
        /// <returns>analyse all data</returns>
        public string getHeartsAnalysis(int age)

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


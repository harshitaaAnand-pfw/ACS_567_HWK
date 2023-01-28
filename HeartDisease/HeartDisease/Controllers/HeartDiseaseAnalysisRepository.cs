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
        public List<HeartDiseaseAnalysis> getHearts()
        {
            return hearts;
        }
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
    }
}


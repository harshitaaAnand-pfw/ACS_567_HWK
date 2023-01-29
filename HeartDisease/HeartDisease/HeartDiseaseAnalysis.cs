using System;
namespace HeartDisease
{
    public class HeartDiseaseAnalysis
    {
        private static int nextId = 1;
        public HeartDiseaseAnalysis(String description)
        {
            Description = description;
            IsCompleted = false;
            Id = nextId++;
        }

        public int Id { get; set; }

        public int Age { get; set; }

        public String Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}


// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace csvFunctions
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter 1 to read the data from CSV file\nEnter 2 to Write the data into CSV file\nEnter 3 to know if prone to heart disease based on age\nEnter 4 to filter by either the age or the gender of the patient\nEnter your option\n");
            int n = Convert.ToInt32(Console.ReadLine());
            string filePath = @"/Users/harshitaaanand/Downloads/archive/heart.csv";
            //Validating the menu
            switch (n)
            {
                case 1:
                    //read from a csv file
                    try
                    {
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    //write into a csv file
                    Console.WriteLine("Enter age:\n");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter your gender:\n");
                    int gender = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter trtbps:\n");
                    int bps = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter cholestrol:\n");
                    int chol = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter restecg:\n");
                    int ecg = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter overall output\n");
                    int output = Convert.ToInt32(Console.ReadLine());
                  //method overloading - calling the function
                    writeRecord(age, gender, bps, chol, ecg, output);
                    break;
                case 3:
                    //data analysis to predict heart disease based on age
                    Console.WriteLine("Predicting if you are prone to heart disease or not\nPlease Enter your age: ");
                    int no = Convert.ToInt32(Console.ReadLine());
                    if (no >= 0 && no <= 18)
                    {
                        Console.WriteLine("You are very less likely prone to a heart disease, still stay active and healthy");
                    }
                    else if (no > 18 && no <= 45)
                    {
                        Console.WriteLine("You may be prone to heart disease if you have a unhealthy lifestyle, Please take regular medical checkups to prevent it ");
                    }
                    else
                    {
                        Console.WriteLine("You are more likeley prone to heart disease, have regular health checkups and have a healthy lifestyle ");
                    }
                    break;
                case 4:
                    //filter in two ways (age and gender)
                    Console.WriteLine("Filter can be done in two ways based on age or gender:-\nEnter either one of the following filter options (age or gender):");
                    String choice = Console.ReadLine();
                    if (choice != null)
                    {
                     //if age is the filter option
                        if (choice.Equals("age"))
                        {
                            Console.WriteLine("Enter the age");
                            String num = Console.ReadLine();
                            Console.WriteLine(string.Join("", readRecord(num, 1)));
                        }
                       //if gender is the filter option 
                        else
                        {
                            Console.WriteLine("Enter the gender 1 for Female and 2 for male");
                            String gen = Console.ReadLine();
                            Console.WriteLine(string.Join("", readRecord(gen, 2)));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter either age or gender");
                    }
                    break;
                default:
                    Console.WriteLine("Please enter the option from the above menu");
                    break;
            }
        }
        //This is the write method to write into CSV file
        public static void writeRecord(int age, int gender, int bps, int chol, int ecg, int output)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/Users/harshitaaanand/Downloads/archive/heart.csv", true))
                {
                    file.WriteLine("\n" + age + "," + gender + "," + bps + "," + chol + "," + ecg + "," + output);

                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("No such file exists to write the data:", e);
            }
        }
        //find the required field method
        public static string[] readRecord(String filterTerm, int position)
        {
            position--;
            string[] recNotFound = { "Record not found" };
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"/Users/harshitaaanand/Downloads/archive/heart.csv");
                for (int i = 0; i < lines.Length; i++)
                {
                    String[] fields = lines[i].Split(',');
                    if (recordMatches(filterTerm, fields, position))
                    {
                        Console.WriteLine("Filtered the records");
                        return fields;
                    }
                }
                return recNotFound;
            }
            catch (Exception e)
            {
                Console.WriteLine("problem in the program");
                return recNotFound;
                throw new ApplicationException("No such file exists to write the data:", e);
            }
        }
        //Method for Matching the fields with filter option 
        public static bool recordMatches(String filterTerm, string[] record, int position)
        {
            if (record[position] == filterTerm)
            {
                return true;
            }
            return false;
        }
    }
}




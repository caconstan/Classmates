using System;

namespace Classmates
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              C#.NET LAB 8: GET TO KNOW YOUR CLASSMATES!
             */
            string cont = "yes";
            string[,] studentInfo = new string[20, 4] {
                { "Amanda", "Detroit", "vegan mac and cheese", "Female" },
                { "Andres", "Midtown", "pizza", "Male" },
                { "Anna", "Livonia", "carrot cake with goat cheese frosting", "Female" },
                { "Christina", "Detroit", "spaghetti", "Female" },
                { "Cody", "Madison Heights", "hamburgers", "Male" },
                { "Delia", "Sterling Heights", "hot dogs", "Female" },
                { "Deshawn", "Warren", "roast beef", "Male" },
                { "Grace", "Eastpointe", "lobster", "Female" },
                { "Jake", "Romulus", "whitefish", "Male" },
                { "James", "Troy", "bbq chicken", "Male" },
                { "Jesse", "Romeo", "tacos", "Male" },
                { "Josh", "St. Clair Shores", "fajitas", "Male" },
                { "Kendall", "Roseville", "french fries", "Male" },
                { "Kyle", "Clinton Township", "lasagna", "Male" },
                { "Michael", "Farmington", "pizza", "Male" },
                { "Nathan", "Farmington Hills", "pizza", "Male" },
                { "Peter", "Taylor", "pizza", "Male" },
                { "Sierra", "Windsor", "pizza", "Female" },
                { "Tommy", "Detroit", "pizza", "Male" },
                { "Vibha", "Detroit", "pizza", "Female" }
            };

            int studentnumber;

            while (cont.Equals("yes"))
            {
                Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about? " +
                    "(enter the student number 1-20 or enter the student's name)");
                getStudentNumber(out studentnumber, studentInfo);
                studentnumber--; // adjustment by 1 for our array indices
                getStudentInfo(studentnumber, studentInfo);
                Console.WriteLine("Would you like to know more? (enter “yes” or “no”)");
                cont = Console.ReadLine();
            }
            Console.WriteLine("Thanks!");
        }

        public static void getStudentInfo(int studentnumber, string[,] studentInfo)
        {
            Console.WriteLine("Student " + (studentnumber+1) + " is " + studentInfo[studentnumber,0] +
                ". What would you like to know about " + studentInfo[studentnumber,0] + "? (enter “hometown”, “favorite food”, or “gender”): ");

            string selection = Console.ReadLine();

            while (selection != "hometown" && selection != "favorite food" && selection != "gender")
            {
                Console.WriteLine("That data does not exist. Please try again. (enter “hometown”, “favorite food”, or “gender”): ");
                selection = Console.ReadLine();
            }

            switch (selection)
            {
                case "hometown":
                    Console.Write(studentInfo[studentnumber, 0] + " is from " + studentInfo[studentnumber, 1] + ". ");
                    break;
                case "favorite food":
                    if (studentInfo[studentnumber, 3] == "Male")
                        Console.Write(studentInfo[studentnumber, 0] + " says his favorite food is " + studentInfo[studentnumber, 2] + ". ");
                    else 
                        Console.Write(studentInfo[studentnumber, 0] + " says her favorite food is " + studentInfo[studentnumber, 2] + ". ");
                    break;
                case "gender":
                    Console.Write(studentInfo[studentnumber, 0] + " identifies as " + studentInfo[studentnumber, 3] + ". ");
                    break;
                default:
                    break;
            }

        }

        public static void getStudentNumber(out int studentnumber, string[,] studentInfo)
        {
            string inputString = Console.ReadLine();

            try
            {
                studentnumber = int.Parse(inputString);
                string name = studentInfo[studentnumber-1,0];
            }
            catch (FormatException)
            {
                for (int i=0; i < studentInfo.Length; i++)
                {
                    if (inputString.Equals(studentInfo[i,0]))
                    {
                        studentnumber = i+1;// adjust again for array indices
                        return;
                    }
                }
                Console.WriteLine("I'm sorry, I didn't understand. Please enter the student number 1-20 or enter the student's name: ");
                getStudentNumber(out studentnumber, studentInfo);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("That student does not exist. Please enter the student number 1-20 or enter the student's name");
                getStudentNumber(out studentnumber, studentInfo);
            }
        }
    }
}

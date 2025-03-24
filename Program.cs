using System;

namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {
        // Declaring Arrays
        static double[] marks = new double[10];
        static int[] Ages = new int[10];
        static string[] names = new string[10];
        static DateTime[] dates = new DateTime[10];
        static int StudentCounter = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                // Menu Options
                Console.WriteLine("\nChoose an Array Exercise:");
                Console.WriteLine("1. Add a new student record (Name, Age, Marks) ");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Find a student by name");
                Console.WriteLine("4. Calculate the class average");
                Console.WriteLine("5. Find the top-performing student ");
                Console.WriteLine("6. Sort students by marks (highest to lowest) ");
                Console.WriteLine("7. Delete a student record");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddNewStudent(); break;
                        case 2: ViewAllStudents(); break;
                        case 3: FindStudentByName(); break;
                        case 4: CalculateClassAverage(); break;
                        case 5: FindTopPerformingStudent(); break;
                        case 6: SortStudentsByMarks(); break;
                        case 7: DeleteStudentRecord(); break;
                        case 0: return;
                        default: Console.WriteLine("Invalid choice! Try again."); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter a number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.ReadLine();
            }
        }

        /* -------------------------- 1. Add New Student  --------------------------*/
        static void AddNewStudent()
        {
            try
            {
                // Declaring Variables
                string StudentName;
                int StudentAge = 0;
                double StudentMark = 0;
                DateTime StudentEnDate = DateTime.Now;

                // Checking if the array is full
                if (StudentCounter == 10)
                {
                    Console.WriteLine("Array is Full! You can't add more students.");
                }
                else
                {
                    Console.WriteLine("\n <--------------- Enter Student Data --------------->");

                    // Getting Student Name
                    for (int i = StudentCounter; i < names.Length; i++)
                    {
                        Console.WriteLine("Enter Student Name: ");
                        StudentName = Console.ReadLine();
                        names[i] = StudentName.ToLower();

                        // Getting Student Age
                        Console.WriteLine("Enter Student Age:  ");
                        StudentAge = int.Parse(Console.ReadLine());

                        // Checking if the age is less than 21
                        while (StudentAge < 21)
                        {
                            Console.WriteLine("Invalid Age! Enter Student Age Again (More Than 21):  ");
                            StudentAge = int.Parse(Console.ReadLine());
                        }
                        Ages[i] = StudentAge;

                        // Getting Student Mark
                        Console.WriteLine("Enter Student Mark: ");
                        StudentMark = double.Parse(Console.ReadLine());

                        // Checking if the mark is between 0 and 100
                        while (StudentMark < 0 || StudentMark > 100)
                        {
                            Console.WriteLine("Invalid Mark! Enter Student Mark Again (0-100):  ");
                            StudentMark = double.Parse(Console.ReadLine());
                        }
                        marks[i] = StudentMark;

                        dates[i] = StudentEnDate;

                        StudentCounter++; // Incrementing the counter

                        Console.WriteLine($"Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");

                        break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter the correct data type.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("(------ Press Enter To Go Back To MENU ------)");
        }

        /* -------------------------- 2. View All Students  --------------------------*/
        static void ViewAllStudents()
        {
            try
            {
                Console.WriteLine("\n*------  List of All Students  ------*\n");

                // Printing all the students
                for (int i = 0; i < StudentCounter; i++)
                {
                    Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /* -------------------------- 3. Find Student By Name   --------------------------*/
        static void FindStudentByName()
        {
            try
            {
                // Declaring Variables
                int index;
                string StudentName;

                // Getting Student Name
                Console.WriteLine("Enter Student Name:");
                StudentName = Console.ReadLine().ToLower();

                index = Array.IndexOf(names, StudentName); // Finding the index of the student

                // Printing the student details
                if (index != -1)
                {
                    Console.WriteLine($"Position: {index} , Name of Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
                }
                else
                {
                    Console.WriteLine("Student does not exist in the array");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a number.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /* -------------------------- 4. Calculate Class Average  --------------------------*/
        static void CalculateClassAverage()
        {
            try
            {
                // Declaring Variables
                double SumOfMarks = 0;
                double ClassAverage = 0;

                // Calculating the class average
                for (int i = 0; i < StudentCounter; i++)
                {
                    SumOfMarks += marks[i];
                }

                ClassAverage = SumOfMarks / StudentCounter; // Calculating the class average
                ClassAverage = Math.Round(ClassAverage, 2); // Rounding the class average to 2 decimal places
                Console.WriteLine($"Class Average: {ClassAverage}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /* -------------------------- 5. Find Top Performing Student  --------------------------*/
        static void FindTopPerformingStudent()
        {
            try
            {
                // Declaring Variables
                double top = 0;
                int index = 0;

                // Finding the top performing student
                for (int i = 0; i < StudentCounter; i++)
                {
                    if (marks[i] > top)
                    {
                        top = marks[i];
                        index = i;
                    }
                }

                Console.WriteLine($"Top Performing Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /* -------------------------- 6. Sort Students By Marks  --------------------------*/
        static void SortStudentsByMarks()
        {
            try
            {
                // Sorting the students by marks
                for (int i = 0; i < StudentCounter; i++)
                {
                    for (int j = i + 1; j < StudentCounter; j++) // compare 1st element with 2nd element
                    {
                        // Declaring Variables
                        double tempMark = marks[i];
                        string tempName = names[i];
                        int tempAge = Ages[i];
                        DateTime tempDate = dates[i];

                        // Swapping the elements
                        if (marks[i] < marks[j])
                        {
                            marks[i] = marks[j];
                            marks[j] = tempMark;

                            names[i] = names[j];
                            names[j] = tempName;

                            Ages[i] = Ages[j];
                            Ages[j] = tempAge;

                            dates[i] = dates[j];
                            dates[j] = tempDate;
                        }
                    }
                }

                Console.WriteLine("*------  Students Sorted by Marks  ------*");

                // Printing the sorted students
                for (int i = 0; i < StudentCounter; i++)
                {
                    Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /* -------------------------- 7. Delete Student Record --------------------------*/
        static void DeleteStudentRecord()
        {
            try
            {
                // Declaring Variables
                int index;
                string StudentName;

                // Getting Student Name
                Console.WriteLine("Enter Student Name:");
                StudentName = Console.ReadLine().ToLower();

                index = Array.IndexOf(names, StudentName);

                if (index != -1)
                {
                    for (int j = index; j < StudentCounter - 1; j++) // Shifting the elements
                    {
                        names[j] = names[j + 1];
                        Ages[j] = Ages[j + 1];
                        marks[j] = marks[j + 1];
                        dates[j] = dates[j + 1];
                    }

                    StudentCounter--; // Decrementing the counter

                    Console.WriteLine("Student Record Deleted Successfully!");

                    for (int k = 0; k < StudentCounter; k++) // Printing the updated students
                    {
                        Console.WriteLine($"{k}: Name of Student: {names[k]} , Student Age: {Ages[k]} , Student Mark: {marks[k]} , Student Enrollment Date: {dates[k]} \n");
                    }
                }
                else
                {
                    Console.WriteLine("Student does not exist in the array");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

using System;

namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {
        //Declearing Arrays
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
                //Menu Options
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

                Console.ReadLine();
            }


        }

        /* -------------------------- 1. Add New Student  -------------------*/
        
        static void AddNewStudent()
        {
            //Declearing Variables
            string StudentName;
            int StudentAge = 0, StudentAge1 = 0;
            double StudentMark = 0;
            DateTime StudentEnDate = DateTime.Now;

            //Checking if the array is full
            if (StudentCounter == 10)
            {
                Console.WriteLine("Array is Full! You can't add more students.");
                
            }
            //If the array is not full
            else
            {
                Console.WriteLine("\n <--------------- Enter Student Data --------------->");

                //Getting Student Name
                for (int i = StudentCounter; i < names.Length; i++)
                {
                    Console.WriteLine("Enter Student Name: ");
                    StudentName = Console.ReadLine();
                    names[i] = StudentName;
                    names[i] = names[i].ToLower();

                    //Getting Student Age
                    Console.WriteLine("Enter Student Age:  ");
                    StudentAge = int.Parse(Console.ReadLine());

                    //Checking if the age is less than 21
                    for (int j = 0; StudentAge < 21; j++)
                    {
                        if (21 > StudentAge)
                        {
                            Console.WriteLine("Invalid Age!");
                            Console.WriteLine("Enter Student Age Again (More Than 21):  ");
                            StudentAge = int.Parse(Console.ReadLine());
                            Ages[i] = StudentAge;
                        }
                        else
                        {
                            Ages[i] = StudentAge;
                        }
                    }

                    Ages[i] = StudentAge;

                    //Getting Student Enrollment Date
                    Console.WriteLine("Enter Student Mark: ");
                    StudentMark = double.Parse(Console.ReadLine());

                    //Checking if the mark is between 0 and 100
                    for (int j = 0; StudentMark < 0 && StudentMark > 100; j++)
                    {
                        if (21 > StudentAge)
                        {
                            Console.WriteLine("Invalid Mark!");
                            Console.WriteLine("Enter Student Mark Again (0-100):  ");
                            StudentAge = int.Parse(Console.ReadLine());
                            marks[i] = StudentMark;
                        }
                        else
                        {
                            marks[i] = StudentMark;
                        }
                    }

                    marks[i] = StudentMark;


                    dates[i] = StudentEnDate;

                    StudentCounter++; //Incrementing the counter

                    Console.WriteLine($"Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");

                    break;

                }

            }
            

            Console.WriteLine("(------ Press Enter To Go Back To MENU ------)");



        }




        /* -------------------------- 2. View All Students  -------------------*/

        static void ViewAllStudents()
        {
            Console.WriteLine("\n*------  List of All Students  ------*\n");

            //Printing all the students
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");

            }

        }


        /* -------------------------- 3. Find Student By Name   -------------------*/

        static void FindStudentByName()
        {
            //Declearing Variables
            int index;
            string StudentName;

            //Getting Student Name
            for (int i = 0; i < StudentCounter; i++)
            {


                Console.WriteLine("Enter Student Name:");
                StudentName = Console.ReadLine();
                StudentName = StudentName.ToLower();

                index = Array.IndexOf(names, StudentName); //Finding the index of the student

                //Printing the student details
                if (index != -1)
                {
                    Console.WriteLine($"Position: {index} , Name of Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");

                }
                else
                {
                    Console.WriteLine("Student is not exists in the array");
                }
            }
        }

        /* -------------------------- 4. Calculate Class Average  -------------------*/

        static void CalculateClassAverage()
        {
            //Declearing Variables
            double SumOfMarks = 0;
            double ClassAverage = 0;

            //Calculating the class average
            for (int i = 0; i < StudentCounter; i++)
            {
                SumOfMarks += marks[i];
            }

            ClassAverage = SumOfMarks / StudentCounter; //Calculating the class average
            ClassAverage = Math.Round(ClassAverage, 2); //Rounding the class average to 2 decimal places
            Console.WriteLine($"Class Average: {ClassAverage}");

        }


        /* -------------------------- 5. Find Top Performing Student  -------------------*/

        static void FindTopPerformingStudent()
        {
            //Declearing Variables
            double top = 0;
            int index = 0;

            //Finding the top performing student
            for (int i = 0; i < StudentCounter; i++)
            {
                if (marks[i] > top)
                {
                    top = marks[i];
                    index = i;
                }



            }
             //index = Array.IndexOf(marks, top);

            Console.WriteLine($"Top Performing Student: {names[index]} , Student Age: {Ages[index]} , Student Mark: {marks[index]} , Student Enrollment Date: {dates[index]} \n");
        }


        /* -------------------------- 6. Sort Students By Marks  -------------------*/

        static void SortStudentsByMarks()
        {
            //Sorting the students by marks
            for (int i = 0; i < StudentCounter; i++)
            {
                
                for (int j = i + 1; j < StudentCounter; j++) //compare 1st element with 2nd element
                {
                    //Declearing Variables
                    double tempMark = marks[i];
                    string tempName = names[i];
                    int tempAge = Ages[i];
                    DateTime tempDate = dates[i];


                    //Swapping the elements
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

            //Printing the sorted students
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"{i}: Name of Student: {names[i]} , Student Age: {Ages[i]} , Student Mark: {marks[i]} , Student Enrollment Date: {dates[i]} \n");
            }
        }



        /* -------------------------- 7. Delete Student Record -------------------*/

        static void DeleteStudentRecord()
        {
            //Declearing Variables
            int index;
            string StudentName;

            //Deleting the student record
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine("Enter Student Name:");
                StudentName = Console.ReadLine();
                StudentName = StudentName.ToLower();

                
                index = Array.IndexOf(names, StudentName);

               
                if (index != -1)
                {
                    
                    for (int j = index; j < StudentCounter - 1; j++) //Shifting the elements
                    {
                        names[j] = names[j + 1];
                        Ages[j] = Ages[j + 1];
                        marks[j] = marks[j + 1];
                        dates[j] = dates[j + 1];
                    }

                    StudentCounter--; //Decrementing the counter

                    Console.WriteLine("Student Record Deleted Successfully!");

                    for (int k = 0; k < StudentCounter; k++) //Printing the updated students
                    {
                        Console.WriteLine($"{k}: Name of Student: {names[k]} , Student Age: {Ages[k]} , Student Mark: {marks[k]} , Student Enrollment Date: {dates[k]} \n");
                    }
                }
                else
                {
                    Console.WriteLine("Student does not exist in the array");
                }
            }

        }
    }
}





using System;
using System.Collections.Generic;
enum Menu
{
    RegisterNewStudent = 1,
    RegisiterNewTeacher,
    GetListPersons
}
namespace HomeWork_1
{
    class Program
    {
        public static PersonList personList = new PersonList();

        public static void Main(string[] args)
        {
            PrintMenuScreen();
        }
        public static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenu.InputMenuFromKeyboard();
        }
        public static void PrintHeader()
        {
            Console.WriteLine("Welcorm to regstration new user school app");
            Console.WriteLine("..........................................");
        }
        public static void PrintListMenu()
        {
            Console.WriteLine("1.Regsiter new student");
            Console.WriteLine("2.Regsiter new teacher");
            Console.WriteLine("3.Get Liist Persorns");
        }
        public static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher");
            Console.WriteLine("....................");
        }
        public static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher :");
            return int.Parse(Console.ReadLine());
        }
        public static int TotalNewStudents()
        {
            Console.Write("Input Total new Student :");
            return int.Parse(Console.ReadLine());
        }
        public static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again");
            InputMenu.InputMenuFromKeyboard();
        }
        public static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student");
            Console.WriteLine("....................");
        }
    }
    class InputMenu
    {
        public static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu :");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
        }
        public static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInput.ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisiterNewTeacher)
            {
                ShowInput.ShowInputRegisterNewTeacherSreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowInput.ShowGetListPersonScreen();
            }
            else
            {
                Program.ShowMessageInputMenuIsInCorrect();
            }
        }
        
    }
    class ShowInput
    {
        public static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonList();
            InputExit.InputExitFromKeyboard();
        }
        public static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            Program.PrintHeaderRegisterStudent();
            int totalStudent = Program.TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }
        public static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                Program.PrintHeaderRegisterStudent();
                Student student = PrintStudent.CreateNewStudent();
                Program.personList.AddNewPerson(student);
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
        public static void ShowInputRegisterNewTeacherSreen()
        {
            Console.Clear();
            Program.PrintHeaderRegisterTeacher();
            int totalTeacher = Program.TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }
        public static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                Program.PrintHeaderRegisterTeacher();
                Teacher teacher = PrintTeacher.CreateNewTeacher();
                Program.personList.AddNewPerson(teacher);
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
    }
    class InputExit
    {
        public static void InputExitFromKeyboard()
        {
            string text = "";

            while (text != "exit")
            {
                Console.WriteLine("Input : exit to Menu");

                text = Console.ReadLine();
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
    }
    class PrintStudent
    {
        public static Student CreateNewStudent()
        {
            return new Student(InputName(), InputAddress(), InputCitizenID(), InputStudentID());
        }
        public static string InputName()
        {
            Console.Write("Name :");
            return Console.ReadLine();
        }
        public static string InputStudentID()
        {
            Console.Write("StudentID :");
            return Console.ReadLine();
        }
        public static string InputAddress()
        {
            Console.Write("Address :");
            return Console.ReadLine();
        }
        public static string InputCitizenID()
        {
            Console.Write("CitizenID :");
            return Console.ReadLine();
        }
    }
    class PrintTeacher
    {
        public static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(), InputAddress(), InputCitizenID(), InputEmployeeID());
        }
        public static Student CreateNewStudent()
        {
            return new Student(InputName(), InputAddress(), InputCitizenID(), InputStudentID());
        }
        public static string InputName()
        {
            Console.Write("Name :");
            return Console.ReadLine();
        }
        public static string InputStudentID()
        {
            Console.Write("StudentID :");
            return Console.ReadLine();
        }
        public static string InputAddress()
        {
            Console.Write("Address :");
            return Console.ReadLine();
        }
        public static string InputCitizenID()
        {
            Console.Write("CitizenID :");
            return Console.ReadLine();
        }
        public static string InputEmployeeID()
        {
            Console.Write("EmployeeID :");
            return Console.ReadLine();
        }
    }
    class Person
    {
        protected string Name;
        protected string Address;
        protected string CitizanID;
        public Person(string name, string address, string citizanID) 
        {
            this.Name = name;
            this.Address = address;
            this.CitizanID = citizanID;
        }
        public string GetName()
        {
            return this.Name;
        }
    }
    class Student : Person
    {
         private string StudentID;

         public Student(string name, string address, string citizanID, string studentID) : base(name, address, citizanID)
         {
             this.StudentID = studentID;
         }
    }
    class Teacher : Person
    {
         private string EmployeeID;

         public Teacher(string name, string address, string citizanID, string employeeID):base(name, address, citizanID)
         {
             this.EmployeeID = employeeID;
         }
    }
    class PersonList
    {
         private List<Person> personList;

         public PersonList()
         {
            this.personList = new List<Person>();
         }
         public void AddNewPerson(Person person)
         {
            this.personList.Add(person);
         }
         public void FetchPersonList()
         {
             Console.WriteLine("List Persons");
             Console.WriteLine("............");
             foreach (Person person in this.personList)
             {
                if (person is Student)
                {
                     Console.WriteLine("Name :{0}\nType:Student\n", person.GetName());
                }
                else if (person is Teacher)
                {
                     Console.WriteLine("Name :{0}\nType:Teacher\n", person.GetName());
                }
             }
         }
    }
}

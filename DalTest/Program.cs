//using Dal;
//using DalApi;
//using DO;
//using System;
//using System.Collections.Generic;
//using static DO.Enums;
////using System.Windows.Forms;
//namespace DalTest

using Dal;
using DalApi;
using DO;
using System;

namespace DalTest
{
    class Program
    {
        // Static fields for DAL interfaces
        private static IVolunteer? s_dalVolunteer = new VolunteerImplementation(); //stage 1
        private static ICall? s_dalCall = new CallImplementation(); //stage 1
        private static IAssignment? s_dalAssignment = new AssignmentImplementation(); //stage 1
        private static IConfig? s_dalConfig = new ConfigImplementation(); //stage 1

        static void Main(string[] args)
        {
            try
            {
                RunMainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void RunMainMenu()
        {
            while (true)
            {
                DisplayMainMenu();

                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch ((MainMenuOption)choice)
                    {
                        case MainMenuOption.Exit:
                            Console.WriteLine("Exiting the program...");
                            return;
                        case MainMenuOption.StudentMenu:
                            HandleSubMenu("Student", s_dalVolunteer);
                            break;
                        case MainMenuOption.CourseMenu:
                            HandleSubMenu("call", s_dalCall);
                            break;
                        case MainMenuOption.LinkMenu:
                            HandleSubMenu("assignmant", s_dalAssignment);
                            break;
                        case MainMenuOption.InitializeData:
                            DoInitialization();
                            break;
                        case MainMenuOption.ShowAllData:
                            ShowAllData();
                            break;
                        case MainMenuOption.ConfigMenu:
                            HandleConfigMenu();
                            break;
                        case MainMenuOption.ResetDatabase:
                            ResetDatabase();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Student Menu");
            Console.WriteLine("2. Course Menu");
            Console.WriteLine("3. Link Menu");
            Console.WriteLine("4. Initialize Data");
            Console.WriteLine("5. Show All Data");
            Console.WriteLine("6. Config Menu");
            Console.WriteLine("7. Reset Database");
            Console.WriteLine("=================");
        }

        private static void HandleSubMenu(string entityName, object? dalObject)
        {
            if (dalObject == null)
            {
                Console.WriteLine($"DAL object for {entityName} is not initialized.");
                return;
            }

            while (true)
            {
                DisplaySubMenu(entityName);

                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch ((SubMenuOption)choice)
                    {
                        case SubMenuOption.Exit:
                            Console.WriteLine($"Exiting {entityName} menu...");
                            return;
                        case SubMenuOption.Create:
                            HandleCreate(entityName, dalObject);
                            break;
                        case SubMenuOption.Read:
                            HandleRead(entityName, dalObject);
                            break;
                        case SubMenuOption.ReadAll:
                            HandleReadAll(entityName, dalObject);
                            break;
                        case SubMenuOption.Update:
                            HandleUpdate(entityName, dalObject);
                            break;
                        case SubMenuOption.Delete:
                            HandleDelete(entityName, dalObject);
                            break;
                        case SubMenuOption.DeleteAll:
                            HandleDeleteAll(entityName, dalObject);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void DisplaySubMenu(string entityName)
        {
            Console.WriteLine($"\n=== {entityName} Menu ===");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read by ID");
            Console.WriteLine("3. Read All");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete by ID");
            Console.WriteLine("6. Delete All");
            Console.WriteLine("=================");
        }

        private static void HandleCreate(string entityName, object dalObject)
        {
            Console.WriteLine($"Creating a new {entityName}...");
            AddVolunteer();

        }

        private static void HandleRead(string entityName, object dalObject)
        {
            Console.WriteLine($"Reading {entityName} by ID...");
            // Implement read logic for specific entity
        }

        private static void HandleReadAll(string entityName, object dalObject)
        {
            Console.WriteLine($"Reading all {entityName}s...");
            // Implement read all logic for specific entity
        }

        private static void HandleUpdate(string entityName, object dalObject)
        {
            Console.WriteLine($"Updating {entityName}...");
            // Implement update logic for specific entity
        }

        private static void HandleDelete(string entityName, object dalObject)
        {
            Console.WriteLine($"Deleting {entityName} by ID...");
            // Implement delete logic for specific entity
        }

        private static void HandleDeleteAll(string entityName, object dalObject)
        {
            Console.WriteLine($"Deleting all {entityName}s...");
            // Implement delete all logic for specific entity
        }

        private static void DoInitialization()
        {
            Console.WriteLine("Initializing database...");
            Initialization.Do(s_dalAssignment, s_dalCall, s_dalVolunteer, s_dalConfig);
        }

        private static void ShowAllData()
        {
            Console.WriteLine("Displaying all data...");
            // Implement logic to display all data
        }

        private static void HandleConfigMenu()
        {
            Console.WriteLine("Handling configuration...");
            // Implement config menu logic
        }

        private static void ResetDatabase()
        {
            Console.WriteLine("Resetting database...");
            s_dalVolunteer?.DeleteAll();
            s_dalCall?.DeleteAll();
            s_dalAssignment?.DeleteAll();
            //s_dalConfig?.ResetConfig();
        }
        private static void AddVolunteer()
        {
            Console.WriteLine("Enter your Id: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id)) { Console.WriteLine("Input to install"); }
            Console.WriteLine("Enter your Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter your PhoneNumber: ");
            string PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter your Location: ");
            string Location = Console.ReadLine();
            Volunteer volunteer = new Volunteer(Id, Name, PhoneNumber, Email, Location, null, null, null, null, false, null, null);
            s_dalVolunteer.Create(volunteer);
        }
    }

    // Enum definitions
    public enum MainMenuOption
    {
        Exit = 0,
        StudentMenu = 1,
        CourseMenu = 2,
        LinkMenu = 3,
        InitializeData = 4,
        ShowAllData = 5,
        ConfigMenu = 6,
        ResetDatabase = 7
    }

    public enum SubMenuOption
    {
        Exit = 0,
        Create = 1,
        Read = 2,
        ReadAll = 3,
        Update = 4,
        Delete = 5,
        DeleteAll = 6
    }
}
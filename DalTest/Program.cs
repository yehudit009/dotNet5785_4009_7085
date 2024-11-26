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
                    switch ((Enums.MainMenuOption)choice)
                    {
                        case Enums.MainMenuOption.Exit:
                            Console.WriteLine("Exiting the program...");
                            Environment.Exit(0);
                            return;
                        case Enums.MainMenuOption.VolunteerMenu:
                            HandleSubMenu("Volunteer", s_dalVolunteer);
                            break;
                        case Enums.MainMenuOption.CallMenu:
                            HandleSubMenu("call", s_dalCall);
                            break;
                        case Enums.MainMenuOption.AssignmantMenu:
                            HandleSubMenu("assignmant", s_dalAssignment);
                            break;
                        case Enums.MainMenuOption.InitializeData:
                            DoInitialization();
                            break;
                        case Enums.MainMenuOption.ShowAllData:
                            ShowAllData();
                            break;
                        case Enums.MainMenuOption.ConfigMenu:
                            HandleConfigSubMenu(s_dalConfig);
                            break;
                        case Enums.MainMenuOption.ResetDatabase:
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
            Console.WriteLine("1. Volunteer Menu");
            Console.WriteLine("2. Call Menu");
            Console.WriteLine("3. Assignmant Menu");
            Console.WriteLine("4. Initialize Data");
            Console.WriteLine("5. Show All Data");
            Console.WriteLine("6. Config Menu");
            Console.WriteLine("7. Reset Database");
            Console.WriteLine("=================");
        }

        private static void DoInitialization()
        {
            Console.WriteLine("Initializing database...");
            Initialization.Do(s_dalAssignment, s_dalCall, s_dalVolunteer, s_dalConfig);
        }

        private static void ShowAllData()
        {
            Console.WriteLine("Displaying all data...");
            ReadAllVolunteer();
            //ReadAllCalls();
            //ReadAllAssignmant();
        }

        private static void HandleConfigSubMenu(object? dalConfig)
        {
            if (dalConfig == null)
            {
                Console.WriteLine("Configuration object is not initialized.");
                return;
            }

            while (true)
            {
                DisplayConfigSubMenu();
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch ((Enums.ConfigMenuOption)choice)
                    {
                        case Enums.ConfigMenuOption.Exit:
                            Console.WriteLine("Exiting Configuration Sub-Menu...");
                            DisplayMainMenu();
                            return;

                        case Enums.ConfigMenuOption.AdvanceClockMinute:
                            updateClockByMinute(1);
                            break;

                        case Enums.ConfigMenuOption.AdvanceClockHour:
                            updateClockByHour(1);
                            break;

                        case Enums.ConfigMenuOption.DisplayClock:
                            ShowCurrentTime();
                            break;

                        case Enums.ConfigMenuOption.SetParameter:
                            //SetParameter();
                            break;

                        case Enums.ConfigMenuOption.DisplayParameter:
                            //DisplayParameter();
                            break;

                        case Enums.ConfigMenuOption.ResetAll:
                            ResetAllConfig();
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

        private static void DisplayConfigSubMenu()
        {
            Console.WriteLine("\n=== Configuration Menu ===");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Advance system clock by one minute");
            Console.WriteLine("2. Advance system clock by one hour");
            Console.WriteLine("3. Display current system clock value");
            Console.WriteLine("4. Set a new value for a configuration parameter");
            Console.WriteLine("5. Display current value of a configuration parameter");
            Console.WriteLine("6. Reset all configuration values");
            Console.WriteLine("===========================");
        }

        private static void updateClockByMinute(int minute)
        {
            DateTime currentClock = s_dalConfig.Clock; // קריאת השעון הנוכחי דרך ה־`get`
            DateTime updatedClock = currentClock + TimeSpan.FromMinutes(minute); // חישוב זמן מעודכן
            s_dalConfig.Clock = updatedClock; // עדכון השעון דרך ה־`set`
            Console.WriteLine($"System clock advanced by {minute} minute(s). Current clock: {s_dalConfig.Clock}");
        }
        private static void updateClockByHour(int hour)
        {
            DateTime currentClock = s_dalConfig.Clock; // קריאת השעון הנוכחי
            DateTime updatedClock = currentClock + TimeSpan.FromHours(hour); // חישוב זמן מעודכן
            s_dalConfig.Clock = updatedClock; // עדכון השעון
            Console.WriteLine($"System clock advanced by {hour} hour(s). Current clock: {s_dalConfig.Clock}");
        }
        private static void ShowCurrentTime()
        {
            Console.WriteLine($"Current clock: {s_dalConfig.Clock}");
        }
        private static void ResetAllConfig()
        {
            s_dalConfig.Reset();
        }

        private static void ResetDatabase()
        {
            Console.WriteLine("Resetting database...");
            s_dalVolunteer?.DeleteAll();
            s_dalCall?.DeleteAll();
            s_dalAssignment?.DeleteAll();
            s_dalConfig?.Reset();
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
                    switch ((Enums.SubMenuOption)choice)
                    {
                        case Enums.SubMenuOption.Exit:
                            Console.WriteLine($"Exiting {entityName} menu...");
                            DisplayMainMenu();
                            return;
                        case Enums.SubMenuOption.Create:
                            HandleCreate(entityName, dalObject);
                            break;
                        case Enums.SubMenuOption.Read:
                            HandleRead(entityName, dalObject);
                            break;
                        case Enums.SubMenuOption.ReadAll:
                            HandleReadAll(entityName, dalObject);
                            break;
                        case Enums.SubMenuOption.Update:
                            HandleUpdate(entityName, dalObject);
                            break;
                        case Enums.SubMenuOption.Delete:
                            HandleDelete(entityName, dalObject);
                            break;
                        case Enums.SubMenuOption.DeleteAll:
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
        //הוספת בדיקה ושליחה למתודה מתאימה לפי class

        private static void HandleCreate(string entityName, object dalObject)
        {
            Console.WriteLine($"Creating a new {entityName}...");
            CreateVolunteer();
        }

        private static void HandleRead(string entityName, object dalObject)
        {
            Console.WriteLine($"Reading {entityName} by ID...");
            ReadVolunteer();
        }

        private static void HandleReadAll(string entityName, object dalObject)
        {
            Console.WriteLine($"Reading all {entityName}s...");
            ReadAllVolunteer();
        }

        private static void HandleUpdate(string entityName, object dalObject)
        {
            Console.WriteLine($"Updating {entityName}...");
            // Implement update logic for specific entity
            UpdateVolunteer();
        }

        private static void HandleDelete(string entityName, object dalObject)
        {
            Console.WriteLine($"Deleting {entityName} by ID...");
            // Implement delete logic for specific entity
            DeleteVolunteer();
        }

        private static void HandleDeleteAll(string entityName, object dalObject)
        {
            Console.WriteLine($"Deleting all {entityName}s...");
            // Implement delete all logic for specific entity
            DeleteAllVolunteer();
        }
        private static void CreateVolunteer()
        {
            Console.WriteLine("Enter your Id: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id)) { Console.WriteLine("Enter Valid Id"); }
            Console.WriteLine("Enter your Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter your PhoneNumber: ");
            string PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter your Password: ");
            string Password = Console.ReadLine();
            Console.WriteLine("Enter your Location: ");
            string Location = Console.ReadLine();
            Volunteer volunteer = new Volunteer(Id, Name, PhoneNumber, Email, Password, Location, null, null, null, false, null, null);
            s_dalVolunteer.Create(volunteer);
        }
        private static void ReadVolunteer()
        {
            Console.WriteLine("Enter Id: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id)) { Console.WriteLine("Enter Valid Id"); }
            Volunteer My = s_dalVolunteer.Read(Id);
            Console.WriteLine(My);
        }
        private static void ReadAllVolunteer()
        {
            List<Volunteer> myList = s_dalVolunteer!.ReadAll();
            // בדיקה אם הרשימה ריקה
            if (myList.Count == 0)
            {
                Console.WriteLine("No volunteers found.");
                return;
            }
            // מעבר על כל הפריטים ברשימה והדפסתם
            Console.WriteLine("List of Volunteers:");
            foreach (var volunteer in myList)
            {
                Console.WriteLine(volunteer); // מתבסס על ToString של Volunteer
            }
        }
        private static void UpdateVolunteer()
        {
            Console.WriteLine("Enter your Id: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id)) { Console.WriteLine("Enter Valid Id"); }
            Console.WriteLine("Enter your Name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter your PhoneNumber: ");
            string PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter your Password: ");
            string Password = Console.ReadLine();
            Console.WriteLine("Enter your Location: ");
            string Location = Console.ReadLine();
            Volunteer volunteer = new Volunteer(Id, Name, PhoneNumber, Email, Password, Location, null, null, null, false, null, null);
            s_dalVolunteer.Update(volunteer);
        }
        private static void DeleteVolunteer()
        {
            Console.WriteLine("Enter Id: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id)) { Console.WriteLine("Enter Valid Id"); }
            s_dalVolunteer.Delete(Id);
            Console.WriteLine("yay");
        }
        private static void DeleteAllVolunteer()
        {
            s_dalVolunteer.DeleteAll();
        }

    }
}
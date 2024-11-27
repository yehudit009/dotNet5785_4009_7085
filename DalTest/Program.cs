using Dal;
using DalApi;
using DO;
using static DO.Enums;

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
                Console.WriteLine("Main Menu");
                Enums.MainMenuOption choice = GetEnumFromUser<Enums.MainMenuOption>();
                switch ((Enums.MainMenuOption)choice)
                {
                    case Enums.MainMenuOption.Exit:
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        return;
                    case Enums.MainMenuOption.VolunteerMenu:
                        HandleSubMenu("volunteer", s_dalVolunteer);
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
            while (true)
            {
                Console.WriteLine("Config Menu");
                Enums.ConfigMenuOption choice = GetEnumFromUser<Enums.ConfigMenuOption>();
                switch (choice)
                {
                    case Enums.ConfigMenuOption.Exit:
                        Console.WriteLine("Exiting Configuration Sub-Menu...");
                        RunMainMenu();
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
        }
        private static void updateClockByMinute(int minute)
        {
            DateTime currentClock = s_dalConfig.Clock;
            DateTime updatedClock = currentClock + TimeSpan.FromMinutes(minute);
            s_dalConfig.Clock = updatedClock;
            Console.WriteLine($"System clock advanced by {minute} minute(s). Current clock: {s_dalConfig.Clock}");
        }
        private static void updateClockByHour(int hour)
        {
            DateTime currentClock = s_dalConfig.Clock;
            DateTime updatedClock = currentClock + TimeSpan.FromHours(hour);
            s_dalConfig.Clock = updatedClock;
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
            while (true)
            {
                Console.WriteLine("Sub Menu");
                Enums.SubMenuOption choice = GetEnumFromUser<Enums.SubMenuOption>();
                switch (choice)
                {
                    case Enums.SubMenuOption.Exit:
                        Console.WriteLine($"Exiting {entityName} menu...");
                        RunMainMenu();
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
        }
        static T GetEnumFromUser<T>() where T : struct, Enum
        {
            while (true)
            {
                foreach (var value in Enum.GetValues(typeof(T)))
                {
                    Console.WriteLine($"{(int)value}. {value}");
                }
                Console.Write("Enter your choice (number): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int selectedValue) && Enum.IsDefined(typeof(T), selectedValue))
                {
                    return (T)(object)selectedValue;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
        private static void HandleCreate(string entityName, object dalObject)
        {
            Console.WriteLine($"Creating a new {entityName}...");
            switch (entityName)
            {
                case "volunteer":
                    CreateVolunteer();
                    break;
                case "call":
                    //CreateCall();
                    break;
                case "assignmant":
                    //CreateAssignmant();
                    break;
                default:
                    break;
            }
        }
        private static void HandleRead(string entityName, object dalObject)
        {
            Console.WriteLine($"Reading {entityName} by ID...");
            switch (entityName)
            {
                case "volunteer":
                    ReadVolunteer();
                    break;
                case "call":
                    //ReadCall();
                    break;
                case "assignmant":
                    //ReadAssignmant();
                    break;
                default:
                    break;
            }
        }
        private static void HandleReadAll(string entityName, object dalObject)
        {
            Console.WriteLine($"Reading all {entityName}s...");
            switch (entityName)
            {
                case "volunteer":
                    ReadAllVolunteer();
                    break;
                case "call":
                    //ReadAllCall();
                    break;
                case "assignmant":
                    //ReadAllAssignmant();
                    break;
                default:
                    break;
            }
        }
        private static void HandleUpdate(string entityName, object dalObject)
        {
            Console.WriteLine($"Updating {entityName}...");
            switch (entityName)
            {
                case "volunteer":
                    UpdateVolunteer();
                    break;
                case "call":
                    //UpdateCall();
                    break;
                case "assignmant":
                    //UpdateAssignmant();
                    break;
                default:
                    break;
            }
        }
        private static void HandleDelete(string entityName, object dalObject)
        {
            Console.WriteLine($"Deleting {entityName} by ID...");
            switch (entityName)
            {
                case "volunteer":
                    DeleteVolunteer();
                    break;
                case "call":
                    //DeleteCall();
                    break;
                case "assignmant":
                    //DeleteAssignmant();
                    break;
                default:
                    break;
            }
        }
        private static void HandleDeleteAll(string entityName, object dalObject)
        {
            Console.WriteLine($"Deleting all {entityName}s...");
            switch (entityName)
            {
                case "volunteer":
                    DeleteAllVolunteer();
                    break;
                case "call":
                    //DeleteAllCall();
                    break;
                case "assignmant":
                    //DeleteAllAssignmant();
                    break;
                default:
                    break;
            }
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
            if (My == null)
            {
                throw new NotImplementedException($"An Volunteer with such ID={Id} does not exist");

            }
            else
            {
                Console.WriteLine(My);
            }
        }
        private static void ReadAllVolunteer()
        {
            List<Volunteer> myList = s_dalVolunteer.ReadAll();
            if (myList.Count == 0)
            {
                throw new NotImplementedException($"no Volunteers found");
                return;
            }
            Console.WriteLine("List of Volunteers:");
            foreach (var volunteer in myList)
            {
                Console.WriteLine(volunteer);
            }
        }
        private static void UpdateVolunteer()
        {
            Console.WriteLine("Enter your Id: ");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id)) { Console.WriteLine("Enter Valid Id"); }
            Volunteer volunteer = s_dalVolunteer.Read(Id);
            Volunteer CopyItem = volunteer;
            if (volunteer == null)
            {
                throw new NotImplementedException($"An Volunteer with such ID={Id} does not exist");
                return;
            }
            Enums.VolunteerProp choice = GetEnumFromUser<Enums.VolunteerProp>();
            switch (choice)
            {
                case VolunteerProp.id:
                    Console.WriteLine("Enter new VolunteerId: ");
                    if (int.TryParse(Console.ReadLine(), out int parsedId))
                    {
                        CopyItem = volunteer with { VolunteerId = parsedId };
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    break;
                case VolunteerProp.name:
                    Console.WriteLine("Enter new Name: ");
                    CopyItem = volunteer with { FullName = Console.ReadLine() };
                    break;
                case VolunteerProp.phoneNumber:
                    Console.WriteLine("Enter new Phone Number: ");
                    CopyItem = volunteer with { PhoneNumber = Console.ReadLine() };
                    break;
                case VolunteerProp.email:
                    Console.WriteLine("Enter new Email: ");
                    CopyItem = volunteer with { Email = Console.ReadLine() };
                    break;
                case VolunteerProp.password:
                    Console.WriteLine("Enter new Password: ");
                    CopyItem = volunteer with { Password = Console.ReadLine() };
                    break;
                case VolunteerProp.address:
                    Console.WriteLine("Enter new Address: ");
                    CopyItem = volunteer with { VolunteerAddress = Console.ReadLine() };
                    break;
                case VolunteerProp.role:
                    Console.WriteLine("Enter new Role (1 for Role1, 2 for Role2, 3 for Role3): ");
                    if (int.TryParse(Console.ReadLine(), out int role))
                    {
                        CopyItem = volunteer with { Role = (Enums.Role)role };
                    }
                    else
                    {
                        Console.WriteLine("Invalid role.");
                    }
                    break;
                case VolunteerProp.isActive:
                    Console.WriteLine("Enter new Is Active (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool isActive))
                    {
                        CopyItem = volunteer with { IsActive = isActive };
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                case VolunteerProp.maxReadingDistance:
                    Console.WriteLine("Enter new Max Reading Distance: ");
                    if (double.TryParse(Console.ReadLine(), out double maxDistance))
                    {
                        CopyItem = volunteer with { MaxReadingDistance = maxDistance };
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                case VolunteerProp.distanceType:
                    Console.WriteLine("Enter new Distance Type (0 for Type1, 1 for Type2): ");
                    if (int.TryParse(Console.ReadLine(), out int distanceType))
                    {
                        CopyItem = volunteer with { DistanceType = (Enums.DistanceType)distanceType };
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            s_dalVolunteer.Update(CopyItem);
            Console.WriteLine("Volunteer updated successfully.");
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
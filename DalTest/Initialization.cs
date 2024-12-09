namespace DalTest;
using DalApi;
using DO;

public class Initialization
{
    // Access to the data layer and a random number generator.
    private static IDal? s_dal = new Dal.DalList(); // Stage 2
    private static readonly Random s_rand = new();

    // Initializes a predefined list of volunteers with random attributes.
    private static void CreateVolunteers()
    {
        // List of volunteer names.
        string[] volunteerNames =
               {
            "Dani Levy", "Eli Amar", "Yair Cohen", "Ariela Levin", "Dina Klein",
            "Shira Israelof", "Tomer Katz", "Rina Green", "Yael Goldman",
            "Barak Shalev", "Omer Haddad", "Hila Peretz", "Eden Barkai",
            "Alon Shamir", "Lior Azulay"
        };

        // Array of real addresses with longitude and latitude
        var addressesWithCoordinates = new (string address, double latitude, double longitude)[]
        {
            ("123 Main St, Tel Aviv, Israel", 32.0853, 34.7818), // Tel Aviv
            ("456 King George St, Jerusalem, Israel", 31.7810, 35.2121), // Jerusalem
            ("789 Herzl St, Haifa, Israel", 32.8105, 34.9876), // Haifa
            ("101 Rothschild Blvd, Tel Aviv, Israel", 32.0658, 34.7693), // Tel Aviv
            ("202 Begin Rd, Rishon LeZion, Israel", 31.9532, 34.8027), // Rishon LeZion
            ("303 Jabotinsky St, Netanya, Israel", 32.3213, 34.8591), // Netanya
            ("404 Bialik St, Holon, Israel", 32.0324, 34.7712), // Holon
            ("505 Ben Yehuda St, Bat Yam, Israel", 32.0182, 34.7509), // Bat Yam
            ("606 Kaplan St, Be'er Sheva, Israel", 31.2510, 34.7913), // Be'er Sheva
            ("707 HaMasger St, Ashdod, Israel", 31.8018, 34.6482) // Ashdod
        };
        // Array of addresses with GPS coordinates.
        bool managerAssigned = false; // Tracks if a manager has already been assigned.

        foreach (var name in volunteerNames)
        {
            int id;
            do
            {
                id = s_rand.Next(200000000, 400000000); // Generate a random ID.
            } while (s_dal.Volunteer.Read(id) != null);

            // Generate other volunteer attributes.
            string phoneNumber = $"05{s_rand.Next(0, 10)}-{s_rand.Next(1000000, 10000000)}";
            string email = $"{name.Replace(" ", ".").ToLower()}@example.com";
            string? password = s_rand.Next(2) == 0 ? $"Pass{id}" : null;

            var selectedAddress = addressesWithCoordinates[s_rand.Next(addressesWithCoordinates.Length)];

            var role = managerAssigned ? Enums.Role.Volunteer : Enums.Role.Manager;
            managerAssigned = true; // Ensure only one manager is assigned.

            bool isActive = s_rand.NextDouble() > 0.2; // 80% chance the volunteer is active.
            double? maxReadingDistance = s_rand.Next(1, 100);
            var distanceType = (Enums.DistanceType)(s_rand.Next(0, 2));

            // Create and add the volunteer to the data source.
            s_dal!.Volunteer.Create(new Volunteer(
                id, name, phoneNumber, email, password,
                selectedAddress.address, selectedAddress.latitude, selectedAddress.longitude,
                role, isActive, maxReadingDistance, distanceType
            ));
        }
    }

    // Initializes a list of calls with random data.
    private static void CreateCalls()
    {
        // List of optional call descriptions
        var callDescriptions = new[]
        {
        "Urgent emergency requiring immediate attention.",
        "Regular maintenance of equipment or facility.",
        "Request for general information regarding services."
    };

        // List of call addresses
        var addresses = new[]
        {
        "123 Main St, CityA", "456 Oak St, CityB", "789 Pine St, CityC"
    };

        var calls = new List<Call>();

        for (int i = 0; i < 50; i++)
        {
            var callType = (Enums.CallType)s_rand.Next(0, Enum.GetValues(typeof(Enums.CallType)).Length);
            string callDescription = callDescriptions[s_rand.Next(callDescriptions.Length)];
            string callAddress = addresses[s_rand.Next(addresses.Length)];
            double callLatitude = 31.5 + s_rand.NextDouble();
            double callLongitude = 34.5 + s_rand.NextDouble();
            DateTime callOpenTime = DateTime.Now.AddMinutes(-s_rand.Next(30, 240));

            bool isAssigned = i < 35;
            DateTime? callCloseTime = null;
            if (i >= 45)
            {
                callCloseTime = callOpenTime.AddMinutes(s_rand.Next(180, 300));
            }

            calls.Add(new Call(0, callType, callDescription, callAddress, callLatitude, callLongitude, callOpenTime, callCloseTime));
        }

        foreach (var call in calls)
        {
            s_dal!.Call.Create(call);
        }
    }

    // Initializes a list of assignments between calls and volunteers.
    private static void CreateAssignments()
    {
        var existingCalls = s_dal!.Call.ReadAll();
        var existingVolunteers = s_dal!.Volunteer.ReadAll();
        int numberOfAssignments = 50;
        var closeTypes = Enum.GetValues(typeof(Enums.CallCloseType)).Cast<Enums.CallCloseType>().ToArray();

        for (int i = 0; i < numberOfAssignments; i++)
        {
            int selectedCallIndex = s_rand.Next(0, existingCalls.Count() - 15);
            var selectedCall = existingCalls.ElementAt(selectedCallIndex);
            DateTime callOpenTime = selectedCall.CallOpenTime.AddMinutes(s_rand.Next(1, 60));
            DateTime? callCloseTime = null;
            Enums.CallCloseType? callCloseType = null;

            if (s_rand.Next(2) == 0)
            {
                callCloseTime = callOpenTime.AddMinutes(s_rand.Next(10, 120));
                callCloseType = closeTypes[s_rand.Next(closeTypes.Length)];
            }
            else
            {
                callCloseType = Enums.CallCloseType.ManagerCancel;
            }

            int selectedVolunteerIndex = s_rand.Next(0, existingVolunteers.Count() - 5);
            int volunteerId = existingVolunteers.ElementAt(selectedVolunteerIndex).VolunteerId;

            s_dal!.Assignment.Create(new Assignment(
                0, selectedCall.CallId, volunteerId,
                callOpenTime, callCloseTime, callCloseType
            ));
        }
    }

    // Main method for initializing the entire database.
    public static void Do(IDal dal) // Stage 2
    {
        Console.WriteLine("Reset Configuration values and List values...");
        s_dal?.ResetDB(); // Stage 2
        Console.WriteLine("Initializing list ...");
        CreateVolunteers();
        CreateCalls();
        CreateAssignments();
    }
}
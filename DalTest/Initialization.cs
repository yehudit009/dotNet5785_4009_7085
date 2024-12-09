namespace DalTest;
using DalApi;
using DO;

public class Initialization
{
    //Method access fields
    //private static ICall? s_dalCall;//stage1
    //private static IVolunteer? s_dalVolunteer;
    //private static IAssignment? s_dalAssignment;
    //private static IConfig? s_dalConfig;
    private static IDal? s_dal;
    private static readonly Random s_rand = new();

    //Initializing the Volunteers lists
    private static void CreateVolunteers()
    {
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
        bool managerAssigned = false; // משתנה לעקוב אם כבר הוקצה מנהל


        foreach (var name in volunteerNames)
        {
            int id;
            do
            {
                id = s_rand.Next(200000000, 400000000); // הגרלת תעודת זהות
            } while (s_dal!.Volunteer.Read(id) != null);

            // שדות נוספים
            string phoneNumber = $"05{s_rand.Next(0, 10)}-{s_rand.Next(1000000, 10000000)}";
            string email = $"{name.Replace(" ", ".").ToLower()}@example.com";
            string? password = s_rand.Next(2) == 0 ? $"Pass{id}" : null; // לפעמים סיסמה ריקה

            // Assign a random address with its coordinates
            var selectedAddress = addressesWithCoordinates[s_rand.Next(addressesWithCoordinates.Length)];

            // אם אין עדיין מנהל, המתנדב הנוכחי יהפוך למנהל, אחרת מתנדב רגיל
            var role = managerAssigned ? Enums.Role.Volunteer : Enums.Role.Manager;
            managerAssigned = true; // לאחר שהוגדר מנהל, נעדכן שהוקצה מנהל

            // Generate other fields
            bool isActive = s_rand.NextDouble() > 0.2;  // 80% מתנדבים פעילים // האם פעיל
            double? maxReadingDistance = s_rand.Next(1, 100); // מרחק מירבי
            var distanceType = (Enums.DistanceType)(s_rand.Next(0, 2)); // הנחה - יש 2 סוגי מרחקים

            // יצירת מתנדב חדש והוספתו
            s_dal!.Volunteer.Create(new Volunteer(
                id,
                name,
                phoneNumber,
                email,
                password,
                selectedAddress.address,
                selectedAddress.latitude,
                selectedAddress.longitude,
                role,
                isActive,
                maxReadingDistance,
                distanceType
            ));
        }
    }

    //Initializing the Call lists
    private static void CreateCalls()
    {

        // תיאורים אפשריים של קריאות
        var callDescriptions = new[]
        {
        "Urgent emergency requiring immediate attention.",
        "Regular maintenance of equipment or facility.",
        "Request for general information regarding services."
    };

        // רשימה של כתובות אפשריות
        var addresses = new[]
        {
        "123 Main St, CityA", "456 Oak St, CityB", "789 Pine St, CityC"
    };
        // רשימת קריאות 
        var calls = new List<Call>();

        for (int i = 0; i < 50; i++)
        {
            var callType = (Enums.CallType)s_rand.Next(0, Enum.GetValues(typeof(Enums.CallType)).Length);
            string callDescription = callDescriptions[s_rand.Next(callDescriptions.Length)];

            // בחירת כתובת רנדומלית
            string callAddress = addresses[s_rand.Next(addresses.Length)];
            // קואורדינטות רנדומליות למיקום הקריאה
            double callLatitude = 31.5 + s_rand.NextDouble();
            double callLongitude = 34.5 + s_rand.NextDouble();

            // זמן פתיחה רנדומלי של הקריאה (לפני הזמן הנוכחי)
            DateTime callOpenTime = DateTime.Now.AddMinutes(-s_rand.Next(30, 240));
            // אם הקריאה לא הוקצתה (15 קריאות)
            bool isAssigned = i < 35; // לפחות 15 קריאות לא הוקצו
            // אם הקריאה פג תוקפן (5 קריאות)
            DateTime? callCloseTime = null;
            if (i >= 45) // לפחות 5 קריאות שפג תוקפן
            {
                callCloseTime = callOpenTime.AddMinutes(s_rand.Next(180, 300)); // קריאה שפג תוקפה
            }
            // הוספת הקריאה לרשימה
            calls.Add(new Call(
                0,
                callType,
                callDescription,
                callAddress,
                callLatitude,
                callLongitude,
                callOpenTime,
                callCloseTime));

            // יצירת קריאה אם היא לא הוקצתה (לפי תנאים)
            if (!isAssigned)
            {
                // קריאה לא הוקצתה (לא נעשה בה טיפול)
                // אין צורך לשייך לה מתנדב
            }
        }
        // הוספת הקריאות למאגר
        foreach (var call in calls)
        {
            s_dal!.Call.Create(call);
        }
    }
    //Initializing the Assignments lists
    private static void CreateAssignments()
    {
        var existingCalls = s_dal!.Call.ReadAll();
        var existingVolunteers = s_dal!.Volunteer.ReadAll();
        // מספר ההקצאות שתרצה ליצור
        int numberOfAssignments = 50;
        // הגדרת סוגי סיום טיפול מתוך Enum
        var closeTypes = Enum.GetValues(typeof(Enums.CallCloseType)).Cast<Enums.CallCloseType>().ToArray();

        for (int i = 0; i < numberOfAssignments; i++)
        {
            int selectedCallIndex = s_rand.Next(0, existingCalls.Count() - 15);
            var selectedCall = existingCalls.ElementAt(selectedCallIndex);
            // זמן טיפול (פתיחה רנדומלית אחרי זמן פתיחה של הקריאה)
            DateTime callOpenTime = selectedCall.CallOpenTime.AddMinutes(s_rand.Next(1, 60));

            // זמן סיום וסוג סיום
            DateTime? callCloseTime = null;
            Enums.CallCloseType? callCloseType = null;

            // חלק מהקריאות מסתיימות
            if (s_rand.Next(2) == 0)
            {
                callCloseTime = callOpenTime.AddMinutes(s_rand.Next(10, 120)); // זמן סיום רנדומלי
                callCloseType = closeTypes[s_rand.Next(closeTypes.Length)]; // סוג סיום אקראי מתוך Enum
            }
            else // קריאות שלא טופלו בזמן
            {
                callCloseType = Enums.CallCloseType.ManagerCancel; // קריאה לא טופלה בזמן - בוטלה ע"י מנהל
            }
            // בחירת מתנדב רנדומלי
            int selectedVolunteerIndex = s_rand.Next(0, existingVolunteers.Count() - 5);
            int volunteerId = existingVolunteers.ElementAt(selectedVolunteerIndex).VolunteerId;

            // יצירת הקצאה חדשה והוספתה
            s_dal!.Assignment.Create(new Assignment(
                0,
            selectedCall.CallId,
            volunteerId,
            callOpenTime,
            callCloseTime,
            callCloseType
            ));
        }
    }

    public static void Do(IDal dal) //stage 2
    {        
        Console.WriteLine("Reset Configuration values and List values...");
        s_dal.ResetDB(); //stage 2
        Console.WriteLine("Initializing list ...");
        CreateVolunteers();
        CreateCalls();
        CreateAssignments();
    }
}
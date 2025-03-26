//namespace DalTest;
//using DalApi;
//using DO;

//public class Initialization
//{
//    // Access to the data layer and a random number generator.
//    private static IDal? s_dal = new Dal.DalList(); // Stage 2
//    private static readonly Random s_rand = new();

//    // Initializes a predefined list of volunteers with random attributes.
//    private static void CreateVolunteers()
//    {
//        // List of volunteer names.
//        string[] volunteerNames =
//               {
//            "Dani Levy", "Eli Amar", "Yair Cohen", "Ariela Levin", "Dina Klein",
//            "Shira Israelof", "Tomer Katz", "Rina Green", "Yael Goldman",
//            "Barak Shalev", "Omer Haddad", "Hila Peretz", "Eden Barkai",
//            "Alon Shamir", "Lior Azulay"
//        };

//        // Array of real addresses with longitude and latitude
//        var addressesWithCoordinates = new (string address, double latitude, double longitude)[]
//        {
//            ("123 Main St, Tel Aviv, Israel", 32.0853, 34.7818), // Tel Aviv
//            ("456 King George St, Jerusalem, Israel", 31.7810, 35.2121), // Jerusalem
//            ("789 Herzl St, Haifa, Israel", 32.8105, 34.9876), // Haifa
//            ("101 Rothschild Blvd, Tel Aviv, Israel", 32.0658, 34.7693), // Tel Aviv
//            ("202 Begin Rd, Rishon LeZion, Israel", 31.9532, 34.8027), // Rishon LeZion
//            ("303 Jabotinsky St, Netanya, Israel", 32.3213, 34.8591), // Netanya
//            ("404 Bialik St, Holon, Israel", 32.0324, 34.7712), // Holon
//            ("505 Ben Yehuda St, Bat Yam, Israel", 32.0182, 34.7509), // Bat Yam
//            ("606 Kaplan St, Be'er Sheva, Israel", 31.2510, 34.7913), // Be'er Sheva
//            ("707 HaMasger St, Ashdod, Israel", 31.8018, 34.6482) // Ashdod
//        };
//        // Array of addresses with GPS coordinates.
//        bool managerAssigned = false; // Tracks if a manager has already been assigned.

//        foreach (var name in volunteerNames)
//        {
//            int id;
//            do
//            {
//                id = s_rand.Next(200000000, 400000000); // Generate a random ID.
//            } while (s_dal.Volunteer.Read(id) != null);

//            // Generate other volunteer attributes.
//            string phoneNumber = $"05{s_rand.Next(0, 10)}-{s_rand.Next(1000000, 10000000)}";
//            string email = $"{name.Replace(" ", ".").ToLower()}@example.com";
//            string? password = s_rand.Next(2) == 0 ? $"Pass{id}" : null;

//            var selectedAddress = addressesWithCoordinates[s_rand.Next(addressesWithCoordinates.Length)];

//            var role = managerAssigned ? Enums.Role.Volunteer : Enums.Role.Manager;
//            managerAssigned = true; // Ensure only one manager is assigned.

//            bool isActive = s_rand.NextDouble() > 0.2; // 80% chance the volunteer is active.
//            double? maxReadingDistance = s_rand.Next(1, 100);
//            var distanceType = (Enums.DistanceType)(s_rand.Next(0, 2));

//            // Create and add the volunteer to the data source.
//            s_dal!.Volunteer.Create(new Volunteer(
//                id, name, phoneNumber, email, password,
//                selectedAddress.address, selectedAddress.latitude, selectedAddress.longitude,
//                role, isActive, maxReadingDistance, distanceType
//            ));
//        }
//    }

//    // Initializes a list of calls with random data.
//    private static void CreateCalls()
//    {
//        // List of optional call descriptions
//        string[] callDescriptions = {
//    "Urgent medical emergency requiring immediate assistance.",
//    "First aid needed for minor injury.",
//    "Transportation assistance for elderly or disabled individuals.",
//    "Meal preparation for those in need.",
//    "Food distribution for low-income families.",
//    "Shelter assistance for homeless individuals.",
//    "Search and rescue operation.",
//    "Mental health crisis intervention.",
//    "Companionship for elderly individuals.",
//    "Babysitting for families in crisis.",
//    "Repair work for homes affected by natural disasters.",
//    "Support for people with disabilities.",
//    "Help with moving or relocation.",
//    "Organizing community events.",
//    "Providing educational support for children.",
//    "Distributing clothing to those in need.",
//    "Collecting and distributing donations.",
//    "Tech support for seniors or those unfamiliar with technology.",
//    "Language translation for non-native speakers.",
//    "Emotional support for victims of domestic violence.",
//    "Assistance with pet care for elderly or sick individuals.",
//    "Escorting individuals to medical appointments.",
//    "Helping farmers or community gardens.",
//    "Building or repairing infrastructure in low-income areas.",
//    "Providing clean water and sanitation aid.",
//    "Fire or natural disaster response support.",
//    "Distributing medical supplies.",
//    "Helping new immigrants settle in.",
//    "Assisting with paperwork and bureaucracy.",
//    "Teaching job skills and resume writing.",
//    "Emergency childcare for parents in crisis.",
//    "Collecting and distributing books for education.",
//    "Hosting recreational activities for children.",
//    "Providing emotional support for grieving individuals.",
//    "Assisting in animal shelters.",
//    "Volunteer help for public libraries.",
//    "Community clean-up projects.",
//    "Repairing or restoring public spaces.",
//    "Tutoring students who need academic support.",
//    "Creating accessibility solutions for disabled individuals.",
//    "Transporting essential supplies to remote areas.",
//    "Fundraising for local causes.",
//    "Distributing hygiene kits to the needy.",
//    "Helping with crisis hotlines.",
//    "Supporting families of deployed military personnel.",
//    "Providing shelter for victims of abuse.",
//    "Reuniting lost individuals with their families.",
//    "Organizing blood donation drives.",
//    "Mental health awareness campaigns.",
//    "Emergency relief efforts in war or disaster zones.",
//    "Helping isolated individuals connect with the community."
//};


//        // List of call addresses
//string[] callAddresses = {
//    "123 Main Street, New York, NY 10001",
//    "456 Elm Avenue, Los Angeles, CA 90012",
//    "789 Oak Drive, Chicago, IL 60610",
//    "101 Maple Lane, Houston, TX 77002",
//    "202 Pine Street, Phoenix, AZ 85004",
//    "303 Cedar Road, Philadelphia, PA 19103",
//    "404 Birch Boulevard, San Antonio, TX 78205",
//    "505 Walnut Court, San Diego, CA 92101",
//    "606 Spruce Circle, Dallas, TX 75201",
//    "707 Chestnut Square, San Jose, CA 95112",
//    "808 Redwood Way, Austin, TX 73301",
//    "909 Magnolia Avenue, Jacksonville, FL 32202",
//    "111 Willow Street, Fort Worth, TX 76102",
//    "222 Poplar Drive, Columbus, OH 43215",
//    "333 Cypress Lane, Charlotte, NC 28202",
//    "444 Palm Road, San Francisco, CA 94103",
//    "555 Aspen Trail, Indianapolis, IN 46204",
//    "666 Sycamore Court, Seattle, WA 98101",
//    "777 Dogwood Place, Denver, CO 80202",
//    "888 Hickory Terrace, Washington, DC 20001",
//    "999 Linden Way, Boston, MA 02108",
//    "135 Bayview Avenue, Miami, FL 33130",
//    "246 Sunset Boulevard, Nashville, TN 37201",
//    "357 Ocean Drive, New Orleans, LA 70112",
//    "468 River Road, Portland, OR 97204",
//    "579 Highland Street, Atlanta, GA 30303",
//    "680 Valley View Lane, Las Vegas, NV 89109",
//    "791 Summit Circle, Kansas City, MO 64106",
//    "802 Crestwood Drive, Minneapolis, MN 55401",
//    "913 Glenwood Avenue, Baltimore, MD 21202",
//    "1021 Meadow Lane, Raleigh, NC 27601",
//    "1132 Forest Drive, Louisville, KY 40202",
//    "1243 Lakeview Court, Detroit, MI 48226",
//    "1354 Parkside Road, Memphis, TN 38103",
//    "1465 Brookside Avenue, Oklahoma City, OK 73102",
//    "1576 Birchwood Drive, Sacramento, CA 95814",
//    "1687 Rosewood Street, Salt Lake City, UT 84101",
//    "1798 Pinecrest Lane, Richmond, VA 23219",
//    "1909 Grandview Road, Providence, RI 02903",
//    "2010 Evergreen Court, Hartford, CT 06103",
//    "2121 Maplewood Terrace, Milwaukee, WI 53202",
//    "2232 Elmwood Drive, Albuquerque, NM 87102",
//    "2343 Cedarwood Lane, Boise, ID 83702",
//    "2454 Redwood Street, Des Moines, IA 50309",
//    "2565 Sycamore Avenue, Omaha, NE 68102",
//    "2676 Hickory Road, Little Rock, AR 72201",
//    "2787 Magnolia Lane, Charleston, SC 29401",
//    "2898 Palm Court, Baton Rouge, LA 70801",
//    "3009 Bayfront Road, Anchorage, AK 99501",
//    "3120 Sunset Drive, Honolulu, HI 96813"
//};
//        double[] Latitudes = new double[]
//{
//            39.7817, 34.0522, 25.7617, 41.8781, 32.7767,
//            40.7128, 33.4484, 30.2672, 47.6062, 39.7392,
//            37.7749, 42.3601, 45.5051, 32.7157, 40.7608,
//            42.3314, 33.7490, 29.7604, 44.9778, 39.9526,
//            28.5383, 39.7684, 32.7767, 27.9506, 36.1627,
//            39.0997, 35.2271, 38.6270, 29.9511, 29.4241,
//            35.7796, 41.4993, 35.1495, 41.8781, 38.9072,
//            37.5407, 25.7617, 29.7604, 34.0522, 47.6062,
//            33.4484, 42.3601, 39.7392, 37.7749, 45.5051,
//            40.7608, 33.7490, 40.7128, 38.6270, 28.5383,
//            27.9506, 35.2271
//};
//        double[] Longitudes = new double[]
//        {
//            -89.6501, -118.2437, -80.1918, -87.6298, -96.7970,
//            -74.0060, -112.0740, -97.7431, -122.3321, -104.9903,
//            -122.4194, -71.0589, -122.6750, -117.1611, -111.8910,
//            -83.0458, -84.3880, -95.3698, -93.2650, -75.1652,
//            -81.3792, -86.1581, -96.7970, -82.4572, -86.7816,
//            -94.5786, -80.8431, -90.1994, -90.0715, -98.4936,
//            -78.6382, -81.6944, -90.0489, -87.6298, -77.0369,
//            -77.4360, -80.1918, -95.3698, -118.2437, -122.3321,
//            -112.0740, -71.0589, -104.9903, -122.4194, -122.6750,
//            -111.8910, -84.3880, -74.0060, -90.1994, -81.3792,
//            -82.4572, -80.8431
//        };

//        var calls = new List<Call>();

//        for (int i = 0; i < 50; i++)
//        {
//            var callType = (Enums.CallType)s_rand.Next(0, Enum.GetValues(typeof(Enums.CallType)).Length);
//            string callDescription = callDescriptions[s_rand.Next(callDescriptions.Length)];
//            string callAddress = callAddresses[s_rand.Next(callAddresses.Length)];
//            double callLatitude = 31.5 + s_rand.NextDouble();
//            double callLongitude = 34.5 + s_rand.NextDouble();
//            DateTime callOpenTime = DateTime.Now.AddMinutes(-s_rand.Next(30, 240));

//            bool isAssigned = i < 35;
//            DateTime? callCloseTime = null;
//            if (i >= 45)
//            {
//                callCloseTime = callOpenTime.AddMinutes(s_rand.Next(180, 300));
//            }

//            calls.Add(new Call(0, callType, callDescription, callAddress, callLatitude, callLongitude, callOpenTime, callCloseTime));
//        }

//        foreach (var call in calls)
//        {
//            s_dal!.Call.Create(call);
//        }
//    }

//    // Initializes a list of assignments between calls and volunteers.
//    private static void CreateAssignments()
//    {
//        var existingCalls = s_dal!.Call.ReadAll();
//        var existingVolunteers = s_dal!.Volunteer.ReadAll();
//        int numberOfAssignments = 50;
//        var closeTypes = Enum.GetValues(typeof(Enums.CallCloseType)).Cast<Enums.CallCloseType>().ToArray();

//        for (int i = 0; i < numberOfAssignments; i++)
//        {
//            int selectedCallIndex = s_rand.Next(0, existingCalls.Count() - 15);
//            var selectedCall = existingCalls.ElementAt(selectedCallIndex);
//            DateTime callOpenTime = selectedCall.CallOpenTime.AddMinutes(s_rand.Next(1, 60));
//            DateTime? callCloseTime = null;
//            Enums.CallCloseType? callCloseType = null;

//            if (s_rand.Next(2) == 0)
//            {
//                callCloseTime = callOpenTime.AddMinutes(s_rand.Next(10, 120));
//                callCloseType = closeTypes[s_rand.Next(closeTypes.Length)];
//            }
//            else
//            {
//                callCloseType = Enums.CallCloseType.ManagerCancel;
//            }

//            int selectedVolunteerIndex = s_rand.Next(0, existingVolunteers.Count() - 5);
//            int volunteerId = existingVolunteers.ElementAt(selectedVolunteerIndex).VolunteerId;

//            s_dal!.Assignment.Create(new Assignment(
//                0, selectedCall.CallId, volunteerId,
//                callOpenTime, callCloseTime, callCloseType
//            ));
//        }
//    }

//    // Main method for initializing the entire database.
//    public static void Do(IDal dal) // Stage 2
//    {

//        Console.WriteLine("Reset Configuration values and List values...");
//        s_dal?.ResetDB(); // Stage 2
//        Console.WriteLine("Initializing list ...");
//        CreateVolunteers();
//        CreateCalls();
//        CreateAssignments();
//    }
//}


namespace DalTest;
using Dal;

using DalApi;
using DO;
using System.Data;
using System;
using static DO.Enums;

public static class Initialization
{
    private static IDal? s_dal; //stage 2
    private static readonly Random s_rand = new();

    private static void CreateCalls()
    {
        string[] CallAddresses = new string[]
        {
            "123 Main St, Springfield, IL 62701",
            "456 Oak Ave, Los Angeles, CA 90001",
            "789 Pine Rd, Miami, FL 33101",
            "101 Maple Dr, Chicago, IL 60601",
            "202 Birch Ln, Dallas, TX 75201",
            "303 Elm St, New York, NY 10001",
            "404 Cedar Blvd, Phoenix, AZ 85001",
            "505 Redwood Way, Austin, TX 73301",
            "606 Willow Ct, Seattle, WA 98101",
            "707 Chestnut Ave, Denver, CO 80201",
            "808 Aspen Blvd, San Francisco, CA 94101",
            "909 Fir St, Boston, MA 02101",
            "1010 Maple Ave, Portland, OR 97201",
            "1111 Pine St, San Diego, CA 92101",
            "1212 Oak Dr, Salt Lake City, UT 84101",
            "1313 Cedar St, Detroit, MI 48201",
            "1414 Birch Ave, Atlanta, GA 30301",
            "1515 Elm Rd, Houston, TX 77001",
            "1616 Willow Dr, Minneapolis, MN 55101",
            "1717 Chestnut Rd, Philadelphia, PA 19101",
            "1818 Redwood Ln, Orlando, FL 32801",
            "1919 Aspen St, Indianapolis, IN 46201",
            "2020 Cedar Dr, Dallas, TX 75202",
            "2121 Fir Ave, Tampa, FL 33601",
            "2222 Maple Ct, Nashville, TN 37201",
            "2323 Oak St, Kansas City, MO 64101",
            "2424 Pine Blvd, Charlotte, NC 28201",
            "2525 Chestnut Ln, St. Louis, MO 63101",
            "2626 Birch Rd, New Orleans, LA 70112",
            "2727 Elm Blvd, San Antonio, TX 78201",
            "2828 Cedar Ave, Raleigh, NC 27601",
            "2929 Willow Rd, Cleveland, OH 44101",
            "3030 Redwood Blvd, Memphis, TN 38101",
            "3131 Fir Ct, Chicago, IL 60602",
            "3232 Pine Ln, Washington, DC 20001",
            "3333 Oak Rd, Richmond, VA 23220",
            "3434 Maple St, Miami, FL 33102",
            "3535 Birch Blvd, Houston, TX 77002",
            "3636 Elm Ct, Los Angeles, CA 90002",
            "3737 Willow St, Seattle, WA 98102",
            "3838 Redwood Ave, Phoenix, AZ 85002",
            "3939 Fir Blvd, Boston, MA 02102",
            "4040 Chestnut Rd, Denver, CO 80202",
            "4141 Aspen Dr, San Francisco, CA 94102",
            "4242 Cedar Ct, Portland, OR 97202",
            "4343 Birch Rd, Salt Lake City, UT 84102",
            "4444 Elm Ln, Atlanta, GA 30302",
            "4545 Willow Blvd, New York, NY 10002",
            "4646 Redwood St, St. Louis, MO 63102",
            "4747 Fir Rd, Orlando, FL 32802",
            "4848 Chestnut Ln, Tampa, FL 33602",
            "4949 Pine Ave, Charlotte, NC 28202"
        };
        double[] Latitudes = new double[]
        {
            39.7817, 34.0522, 25.7617, 41.8781, 32.7767,
            40.7128, 33.4484, 30.2672, 47.6062, 39.7392,
            37.7749, 42.3601, 45.5051, 32.7157, 40.7608,
            42.3314, 33.7490, 29.7604, 44.9778, 39.9526,
            28.5383, 39.7684, 32.7767, 27.9506, 36.1627,
            39.0997, 35.2271, 38.6270, 29.9511, 29.4241,
            35.7796, 41.4993, 35.1495, 41.8781, 38.9072,
            37.5407, 25.7617, 29.7604, 34.0522, 47.6062,
            33.4484, 42.3601, 39.7392, 37.7749, 45.5051,
            40.7608, 33.7490, 40.7128, 38.6270, 28.5383,
            27.9506, 35.2271
        };
        double[] Longitudes = new double[]
        {
            -89.6501, -118.2437, -80.1918, -87.6298, -96.7970,
            -74.0060, -112.0740, -97.7431, -122.3321, -104.9903,
            -122.4194, -71.0589, -122.6750, -117.1611, -111.8910,
            -83.0458, -84.3880, -95.3698, -93.2650, -75.1652,
            -81.3792, -86.1581, -96.7970, -82.4572, -86.7816,
            -94.5786, -80.8431, -90.1994, -90.0715, -98.4936,
            -78.6382, -81.6944, -90.0489, -87.6298, -77.0369,
            -77.4360, -80.1918, -95.3698, -118.2437, -122.3321,
            -112.0740, -71.0589, -104.9903, -122.4194, -122.6750,
            -111.8910, -84.3880, -74.0060, -90.1994, -81.3792,
            -82.4572, -80.8431
        };
        string[] Information = {
    "Urgent medical emergency requiring immediate assistance.",
    "First aid needed for minor injury.",
    "Transportation assistance for elderly or disabled individuals.",
    "Meal preparation for those in need.",
    "Food distribution for low-income families.",
    "Shelter assistance for homeless individuals.",
    "Search and rescue operation.",
    "Mental health crisis intervention.",
    "Companionship for elderly individuals.",
    "Babysitting for families in crisis.",
    "Repair work for homes affected by natural disasters.",
    "Support for people with disabilities.",
    "Help with moving or relocation.",
    "Organizing community events.",
    "Providing educational support for children.",
    "Distributing clothing to those in need.",
    "Collecting and distributing donations."
        };
        string[] Maintenance = {
    "Helping farmers or community gardens.",
    "Building or repairing infrastructure in low-income areas.",
    "Providing clean water and sanitation aid.",
    "Fire or natural disaster response support.",
    "Distributing medical supplies.",
    "Helping new immigrants settle in.",
    "Assisting with paperwork and bureaucracy.",
    "Teaching job skills and resume writing.",
    "Emergency childcare for parents in crisis.",
    "Collecting and distributing books for education.",
    "Hosting recreational activities for children.",
    "Providing emotional support for grieving individuals.",
    "Assisting in animal shelters.",
    "Volunteer help for public libraries.",
    "Community clean-up projects.",
    "Repairing or restoring public spaces.",
    "Tutoring students who need academic support."
      };
        string[] Emergency = {
    "Helping farmers or community gardens.",
    "Building or repairing infrastructure in low-income areas.",
    "Providing clean water and sanitation aid.",
    "Fire or natural disaster response support.",
    "Distributing medical supplies.",
    "Helping new immigrants settle in.",
    "Assisting with paperwork and bureaucracy.",
    "Teaching job skills and resume writing.",
    "Emergency childcare for parents in crisis.",
    "Collecting and distributing books for education.",
    "Hosting recreational activities for children.",
    "Providing emotional support for grieving individuals.",
    "Assisting in animal shelters.",
    "Volunteer help for public libraries.",
    "Community clean-up projects.",
    "Repairing or restoring public spaces.",
    "Tutoring students who need academic support.",
    "Repairing or restoring public spaces.",
    "Tutoring students who need academic support."
      };

        Random random = new();

        for (int i = 0; i < 16; i++)
        {
            //Console.WriteLine($"Clock Type: {s_dal.Config!.Clock.GetType()}");
            //Console.WriteLine($"Clock Value: {s_dal.Config!.Clock}");

            //var startRange = s_dal.Config!.Clock.AddDays(-30);
            //Console.WriteLine('1');

            //var openTime = startRange.AddMinutes(s_rand.Next(0, (int)(s_dal.Config.Clock - startRange).TotalMinutes));

            //DateTime? maxFinish = s_rand.Next(100) < 70 ?
            //openTime.AddHours(s_rand.Next(1, 25)) : null;
            DateTime openHour = DateTime.Now;
            DateTime closeHour = DateTime.Now;

            Call call = new(0, CallType.Information, Information[i], CallAddresses[i], Latitudes[i], Longitudes[i], openHour, closeHour);
            s_dal.Call?.Create(call);
        }

        for (int i = 0; i < 16; i++)
        {
            DateTime openHour = DateTime.Now;
            DateTime closeHour = DateTime.Now;
            Call call = new(0, CallType.Maintenance, Maintenance[i], CallAddresses[i], Latitudes[i], Longitudes[i], openHour, closeHour);
            s_dal.Call?.Create(call);
        }

        for (int i = 0; i < 18; i++)
        {
            DateTime openHour = DateTime.Now;
            DateTime closeHour = DateTime.Now;
            Call call = new(0, CallType.Emergency, Emergency[i], CallAddresses[i], Latitudes[i], Longitudes[i], openHour, closeHour);
            s_dal.Call?.Create(call);
        }

    }

    private static void CreateVolunteers()
    {
        Random random = new();
        string[] firstNames = new string[]
        {
            "John", "Jane", "Michael", "Emily", "William",
            "Sophia", "James", "Isabella", "Liam", "Olivia",
            "Ethan", "Ava", "Mason", "Mia", "Alexander",
            "Charlotte", "Lucas", "Amelia", "Henry", "Ella"
        };
        string[] lastNames = new string[]
        {
            "Smith", "Johnson", "Brown", "Taylor", "Anderson",
            "Thomas", "Jackson", "White", "Harris", "Martin",
            "Thompson", "Garcia", "Martinez", "Robinson", "Clark",
            "Rodriguez", "Lewis", "Walker", "Young", "Allen"
        };
        string[] emails = new string[] {
          "daniel@gmail.com",
          "michal123@gmail.com",
          "avi.levi@gmail.com",
          "sara.cohen@outlook.com",
          "noam.benDavid@walla.co.il",
          "yael.mizrahi@hotmail.com",
          "david.rosenberg@example.org",
          "shira.shapira@gmail.com",
          "ron.abramovich@mail.com",
          "tal.katz@icloud.com",
          "yoni.goldman@gmail.com",
          "maya.fischer@outlook.com",
          "omer.shalom@yahoo.com",
          "hila.azoulay@hotmail.com",
          "nadav.barak@walla.co.il",
          "tamar.erez@mail.com",
          "ilan.sharon@example.com",
          "gila.zohar@icloud.com",
          "ben.tzur@gmail.com",
          "efrat.harel@yahoo.com"
        };
        string[] phoneNumbers = new string[]
         {
            "0501234567", "0522345678", "0533456789", "0544567890", "0555678901",
            "0586789012", "0509876543", "0528765432", "0537654321", "0546543210",
            "0555432109", "0584321098", "0503210987", "0522109876", "0531098765",
            "0540987654", "0559876501", "0588765402", "0507654303", "0526543204"
         };
        string[] passwords = new string[]
        {
            "A1b!cD2@eF3g",
            "Xy9$Zx8@Uv7^",
            "Qw4#Er5$Ty6%",
            "Pl2!Ok3@Ij4^",
            "Mn5$Bh6#Vg7@",
            "Tg8&Yh9*Ui1!",
            "Lo2%Ki3^Ju4@",
            "Re5#Wd6$Ft7%",
            "Zx9&Cv8*Bn7@",
            "Gh3!Jk2@Lm4$",
            "Ab7$Cd9@Ef8%",
            "Yz2#Xx4@Wu5^",
            "Pa6$Sm8@Ln7%",
            "Nt9&Jm3*Hi2!",
            "Vl4%Pk6^Mj5@",
            "Fc7$Dt8#Er9%",
            "Wx2#Qz5@Rt6$",
            "Lm8@Po9%Na7^",
            "Tj6*Ui4#Yh3&",
            "Ba5^Cb6$Dc7@"
        };
        string[] addresses = new string[]
        {
            "רחוב דיזנגוף 100, תל אביב",
            "רחוב הרצל 25, ראשון לציון",
            "רחוב בן גוריון 50, חולון",
            "רחוב חיפה 15, נתניה",
            "רחוב ירושלים 88, באר שבע",
            "רחוב הנשיא 2, פתח תקווה",
            "שדרות רוטשילד 18, תל אביב",
            "רחוב העצמאות 30, אשדוד",
            "רחוב הגפן 12, רחובות",
            "רחוב דרך הים 45, חיפה",
            "רחוב הכרמל 5, רמת גן",
            "רחוב השקד 9, כפר סבא",
            "רחוב אבן גבירול 75, תל אביב",
            "רחוב הזיתים 22, רעננה",
            "רחוב השושנים 14, גבעתיים",
            "שדרות בן צבי 20, אשקלון",
            "רחוב ויצמן 33, הרצליה",
            "רחוב עמק רפאים 10, ירושלים",
            "רחוב נעמי שמר 8, מודיעין",
            "רחוב אלנבי 60, תל אביב"
        };

        Volunteer Manager = new(random.Next(200000000, 400000001), "yael choen", "0501234567", "ayalaMeruven@gmail.com", "A1b!c89&eF3g", "רחוב דיזנגוף 10, תל אביב", null, null, Role.Manager, true,null, DistanceType.AirDistance);
        Volunteer? checkManager = s_dal!.Volunteer.Read(Manager.VolunteerId);
        if (checkManager == null)
        {
            s_dal.Volunteer.Create(Manager);
        }

        for (int i = 0; i < 20; i++)
        {
            Volunteer volunteer = new(
                random.Next(200000000, 400000001),
                firstNames[i],
                phoneNumbers[i],
                emails[i],
                passwords[i],
                addresses[i],
                null,
                null,
                Role.Volunteer,
                true,
                random.Next(1, 101),
                DistanceType.AirDistance);
            Volunteer? checkVolunteer = s_dal.Volunteer.Read(volunteer.VolunteerId);
            if (checkVolunteer == null)
            {
                s_dal.Volunteer.Create(volunteer);
            }
        }
    }

    private static void CreateAssignments()
    {
        // טווח לפני ואחרי זמן הסיום
        TimeSpan rangeBefore = TimeSpan.FromHours(5); // עד 5 שעות לפני
        TimeSpan rangeAfter = TimeSpan.FromHours(3);  // עד 3 שעות אחרי

        int timesGreater = 0; // מונה למקרים ש-randomTime יהיה גדול מ-EndCallTime

        var existingCalls = s_dal!.Call.ReadAll();
        var callsSize = existingCalls.Count();
        Console.WriteLine(callsSize);

        for (int i = 0; i < 50; i++)
        {
            int randomIndexCall = s_rand.Next(0, callsSize - 15);
            int randomIndexVolunteer = s_rand.Next(0, s_dal!.Volunteer.ReadAll().Count() - 5);
            int selectedIdCall = s_dal.Call.ReadAll().ElementAt(randomIndexCall).CallId;
            TimeSpan timeSpan = (TimeSpan)(s_dal.Call.Read(selectedIdCall).CallCloseTime - s_dal.Call.Read(selectedIdCall).CallOpenTime);
            double randomSeconds = s_rand.NextDouble() * timeSpan.TotalSeconds;

            DateTime endCallTime = (DateTime)s_dal.Call.Read(selectedIdCall).CallCloseTime;
            DateTime randomTime;
            CallCloseType endTypeAssignment;
            // שליטה בערך של randomTime
            if (timesGreater < 25 && i >= 30) // 20 פעמים ש-randomTime יהיה אחרי EndCallTime
            {
                double randomOffsetInSeconds = s_rand.NextDouble() * rangeAfter.TotalSeconds;
                randomTime = endCallTime.AddSeconds(randomOffsetInSeconds); // זמן אחרי EndCallTime
                timesGreater++;
                endTypeAssignment = (CallCloseType)s_rand.Next(0, 4);
            }
            else // 30 פעמים ש-randomTime יהיה קטן או שווה ל-EndCallTime
            {
                double randomOffsetInSeconds = -(s_rand.NextDouble() * rangeBefore.TotalSeconds);
                randomTime = endCallTime.AddSeconds(randomOffsetInSeconds); // זמן לפני EndCallTime
                endTypeAssignment = CallCloseType.ExpiredCancel;
            }

            // יצירת אובייקט Assignment
            Assignment assignment = new Assignment(
                0,
                selectedIdCall,
                s_dal.Volunteer.ReadAll().ElementAt(randomIndexVolunteer).VolunteerId,
                s_dal.Call.Read(selectedIdCall)!.CallOpenTime,
                s_dal.Call.Read(selectedIdCall)!.CallOpenTime.AddSeconds(randomSeconds),
                //randomTime,
                endTypeAssignment
            );

            // בדיקת קיום והוספת Assignment
            Assignment? checkAssignment = s_dal.Assignment.Read(assignment.AssignmentId);
            if (checkAssignment == null)
            {
                s_dal.Assignment.Create(assignment);
            }
        }
    }

    public static void Do(IDal dal) //stage 2
    {
        s_dal = dal ?? throw new NullReferenceException("DAL object can not be null!"); // stage 2
        Console.WriteLine("Reset Configuration values and List values...");
        s_dal.ResetDB(); //stage 2
        CreateCalls();
        Console.WriteLine("calls...");

        CreateVolunteers();
        Console.WriteLine("volunteers...");

        CreateAssignments();
        Console.WriteLine("assignments...");
    }
}
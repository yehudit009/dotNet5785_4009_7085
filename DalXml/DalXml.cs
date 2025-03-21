/// <summary>
/// Main Data Access Layer implementation using XML storage.
/// Provides access to all entity repositories and database operations.
/// </summary>
namespace Dal;
using DalApi;

sealed public class DalXml : IDal
{
    public IAssignment Assignment { get; } = new AssignmentImplementation();
    public ICall Call { get; } = new CallImplementation();
    public IVolunteer Volunteer { get; } = new VolunteerImplementation();
    public IConfig Config { get; } = new ConfigImplementation();
    public void ResetDB()
    {
        Assignment.DeleteAll();
        Call.DeleteAll();
        Volunteer.DeleteAll();
        Config.Reset();
    }

}
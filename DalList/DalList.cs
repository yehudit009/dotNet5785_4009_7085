﻿namespace Dal;
using DalApi;
sealed public class DalList : IDal
{
    public ICall Call { get; } = new CallImplementation();
    public IVolunteer Volunteer { get; } = new VolunteerImplementation();
    public IAssignment Assignment { get; } = new AssignmentImplementation();
    public IConfig Config { get; } = new ConfigImplementation();

    public void ResetDB()
    {
        Call.DeleteAll();
        Volunteer.DeleteAll();
        Assignment.DeleteAll();
        Config.Reset();
    }
}

namespace DO;

public static class Enums
{
    public enum CallType
    {
        Emergency,    // חירום
        Maintenance,  // תחזוקה
        Information   // מידע
    }
    public enum CallStatus
    {
        Open,         // פתוחה
        Closed,       // סגורה
        Expired,      // פגה תוקף
        InProgress    // בטיפול
    }
    public enum CallCloseType
    {
        Handled,      // טופלה
        SelfCancel,   // ביטול עצמי
        ManagerCancel // ביטול על ידי מנהל
    }
    public enum Role
    {
        Volunteer,    // מתנדב
        Manager       // מנהל
    }
    public enum DistanceType
    {
        AirDistance,  // מרחק אווירי
        WalkingDistance // מרחק הליכה
    }
    public enum MainMenuOption
    {
        Exit = 0,
        VolunteerMenu = 1,
        CallMenu = 2,
        AssignmantMenu = 3,
        InitializeData = 4,
        ShowAllData = 5,
        ConfigMenu = 6,
        ResetDatabase = 7
    }

    // Enum for sub-menu options
    public enum SubMenuOption
    {
        Exit = 0,
        Create = 1,
        Read = 2,
        ReadAll = 3,
        Update = 4,
        Delete = 5,
        DeleteAll = 6,
        HandleExceptions = 7
    }
    public enum ConfigMenuOption
    {
        Exit = 0,
        AdvanceClockMinute = 1,
        AdvanceClockHour = 2,
        DisplayClock = 3,
        SetParameter = 4,
        DisplayParameter = 5,
        ResetAll = 6
    }

}

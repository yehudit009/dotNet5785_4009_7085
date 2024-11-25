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
        ShowEntity1Menu = 1,
        ShowEntity2Menu = 2,
        ShowEntity3Menu = 3,
        InitializeData = 5,
        ShowAllData = 6,
        ShowConfigMenu = 7,
        ResetDatabase = 8
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

}

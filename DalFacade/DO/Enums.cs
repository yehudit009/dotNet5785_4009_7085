namespace DO;

public static class Enums
{
    // Enum לסוגי קריאות
    public enum CallType
    {
        Emergency,    // חירום
        Maintenance,  // תחזוקה
        Information   // מידע
    }

    // Enum למצב הקריאה (פתוחה, סגורה, וכו')
    public enum CallStatus
    {
        Open,         // פתוחה
        Closed,       // סגורה
        Expired,      // פגה תוקף
        InProgress    // בטיפול
    }

    // Enum לסוגי סיום טיפול בהקצאה
    public enum CallCloseType
    {
        Handled,      // טופלה
        SelfCancel,   // ביטול עצמי
        ManagerCancel // ביטול על ידי מנהל
    }

    // Enum למידע על תפקיד המתנדב
    public enum Role
    {
        Volunteer,    // מתנדב
        Manager       // מנהל
    }

    // Enum לסוגי מרחקים (למשל: מרחק אווירי, מרחק הליכה)
    public enum DistanceType
    {
        AirDistance,  // מרחק אווירי
        WalkingDistance // מרחק הליכה
    }
}

namespace Dal;
internal  static class Config
{
    //מספר רץ
    internal const int firstCallId = 0;
    private static int nextCallId = firstCallId;
    internal static int NextCallId { get => nextCallId++; }

    internal const int firstAssignmentId = 0;
    private static int nextAssignmentId = firstAssignmentId;
    internal static int NextAssignmentId { get => nextAssignmentId++; }

    internal static DateTime Clock { get; set; } = DateTime.Now;
    internal static TimeSpan RiskRange { get; set; } = TimeSpan.Zero;
    internal static void Reset()
    {
        nextCallId = firstCallId;
        nextAssignmentId = firstAssignmentId;
        Clock= DateTime.Now;
        RiskRange = TimeSpan.Zero;
    }
}
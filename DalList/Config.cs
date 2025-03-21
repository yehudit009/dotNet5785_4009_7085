namespace Dal;

/// <summary>
/// Static configuration class that manages unique IDs, clock settings, and 
/// range.
/// </summary>
internal static class Config
{
    // Starting values for IDs
    internal const int firstCallId = 0;
    private static int nextCallId = firstCallId;
    internal static int NextCallId { get => nextCallId++; }

    internal const int firstAssignmentId = 0;
    private static int nextAssignmentId = firstAssignmentId;
    internal static int NextAssignmentId { get => nextAssignmentId++; }

    /// Represents the current time used in the system.
    internal static DateTime Clock { get; set; } = DateTime.Now;

    /// Resets all configurations to their initial state.
    internal static void Reset()
    {
        nextAssignmentId = firstCallId;
        Clock = DateTime.Now;
    }
}

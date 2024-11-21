/// Module Call.cs
namespace DO;

/// <summary>
/// Call Entity represents a call with all its props
/// </summary>
/// <param name="CallId">A unique number for each call.</param>
/// <param name="CallType">The type of the call (enum).</param>
/// <param name="CallDescription">A description of the call.</param>
/// <param name="CallAddress">The address where the call occurred.</param>
/// <param name="CallLatitude">The latitude of the call location.</param>
/// <param name="CallLongitude">The longitude of the call location.</param>
/// <param name="CallOpenTime">The time when the call was opened.</param>
/// <param name="CallCloseTime">The time when the call was closed.</param>
public record Call
(
     int CallId,
     Enum CallType,
     string? CallDescription,
     string CallAddress,
     double CallLatitude,
     double CallLongitude,
     DateTime CallOpenTime,
     DateTime? CallCloseTime
)
{
    /// Default constructor for stage 3
    public Assignment() : this(0, 0, 0, DateTime.Now, DateTime.Now, null) { }
}
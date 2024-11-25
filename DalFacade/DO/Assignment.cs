/// Module Assignment.cs

namespace DO;
/// <summary>
/// Assignment Entity represents an Assignment with all its props
/// </summary>
/// <param name="AssignmentId">An ID number for each call assignment to a volunteer.</param>
/// <param name="CallId">The number of the call the volunteer chose.</param>
/// <param name="VolunteerId">The id of the voluneer who chose the call.</param>
/// <param name="CallOpenTime">The time when the volunteer took the call.</param>
/// <param name="CallCloseTime">The time when the volunteer finished handeling the call.</param>
/// <param name="CallCloseType">The manner in which the reading treatment ended.</param>
public record Assignment
(
    int AssignmentId,
    int CallId,
    int VolunteerId,
    DateTime CallOpenTime,
    DateTime? CallCloseTime,
    Enum? CallCloseType
)
{
    /// Default constructor for stage 3
    public Assignment() : this(0, 0, 0, DateTime.Now, DateTime.Now, null) { }
}
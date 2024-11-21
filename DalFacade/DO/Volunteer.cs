/// Module Volunteer.cs
namespace DO;

/// <summary>
/// Volunteer Entity represents a Volunteer with all its props
/// </summary>
/// <param name="VolunteerId">Personal unique ID of the Volunteer (as in national id card)</param>
/// <param name="FullName">Full Name of the Volunteer.</param>
/// <param name="PhoneNumber">Phone Number of the Volunteer.</param>
/// <param name="Email">Email of the Volunteer.</param>
/// <param name="Password">Password of the Volunteer.</param>
/// <param name="VolunteerAddress">The current location of the volunteer, useful for calculating the distance at which they are available to receive calls.</param>
/// <param name="VolunteerLatitude">The latitude of the volunteer location.</param>
/// <param name="VolunteerLongitude">The longitude of the volunteer location.</param>
/// <param name="Role">The role of the Volunteer, manager or regular volunteer.</param>
/// <param name="IsActive">>whether the Volunteer is active or retire.</param>
/// <param name="MaxReadingDistance">The maximum distance at which the volunteer can choose a call.</param>
/// <param name="DistanceType">Distance type (air distance, walking distance, etc...)</param>
public record Volunteer
(
    int VolunteerId,
    string FullName,
    string PhoneNumber,
    string Email,
    string? Password,
    string? VolunteerAddress,
    double? VolunteerLatitude,
    double? VolunteerLongitude,
    Enum Role,
    bool IsActive,
    double? MaxReadingDistance,
    Enum DistanceType
)
{
    /// Default constructor
    public Volunteer() : this(0, "", "", "", null, null, null, null, null, false, null, null) { }
}

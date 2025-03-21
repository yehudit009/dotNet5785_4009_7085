namespace Dal;
using DalApi;
using DO;
using System.Xml.Linq;

internal class VolunteerImplementation : IVolunteer
{
    /// <summary>
    /// Converts an XML element to a Volunteer object
    /// </summary>
    /// <param name="v">XML element containing volunteer data</param>
    /// <returns>Volunteer object populated with data from XML</returns>
    static Volunteer GetVolunteer(XElement v)
    {
        return new DO.Volunteer()
        {
            VolunteerId = v.ToIntNullable("Id") ?? throw new FormatException("Invalid ID format"),
            FullName = (string?)v.Element("Name") ?? "",
            Address = (string?)v.Element("Address") ?? "",
            Phone = (string?)v.Element("Phone") ?? "",
            IsAvailable = (bool?)v.Element("IsAvailable") ?? false,
            StartDate = v.ToDateTimeNullable("StartDate") ?? DateTime.MinValue
        };
    }

    /// <summary>
    /// Creates a sequence of XML elements representing volunteer properties
    /// </summary>
    /// <param name="volunteer">Volunteer object to convert to XML</param>
    /// <returns>IEnumerable of XElements for each volunteer property</returns>
    private static IEnumerable<XElement> CreateVolunteerElements(Volunteer volunteer)
    {
        yield return new XElement("Id", volunteer.VolunteerId);
        yield return new XElement("Name", volunteer.FullName);
        yield return new XElement("Address", volunteer.Address);
        yield return new XElement("Phone", volunteer.Phone);
        yield return new XElement("IsAvailable", volunteer.IsAvailable);
        yield return new XElement("StartDate", volunteer.StartDate);
    }

    public void Create(Volunteer volunteer)
    {
        XElement volunteersRootElem = XMLTools.LoadListFromXMLElement(Config.s_volunteers);

        if (volunteersRootElem.Elements().Any(v => (int?)v.Element("Id") == volunteer.VolunteerId))
            throw new DalAlreadyExistsException($"Volunteer with ID {volunteer.VolunteerId} already exists.");

        volunteersRootElem.Add(new XElement("Volunteer", CreateVolunteerElements(volunteer)));
        XMLTools.SaveListToXMLElement(volunteersRootElem, Config.s_volunteers);
    }

    public Volunteer? Read(int id)
    {
        XElement volunteersRootElem = XMLTools.LoadListFromXMLElement(Config.s_volunteers);
        XElement? volunteerElement = volunteersRootElem.Elements()
            .FirstOrDefault(v => (int?)v.Element("Id") == id);

        return volunteerElement != null ? GetVolunteer(volunteerElement) : null;
    }

    public void Update(Volunteer volunteer)
    {
        XElement volunteersRootElem = XMLTools.LoadListFromXMLElement(Config.s_volunteers);
        XElement? volunteerElement = volunteersRootElem.Elements()
            .FirstOrDefault(v => (int?)v.Element("Id") == volunteer.VolunteerId) ?? throw new DalDoesNotExistException($"Volunteer with ID {volunteer.VolunteerId} not found.");
        volunteerElement.ReplaceWith(new XElement("Volunteer", CreateVolunteerElements(volunteer)));
        XMLTools.SaveListToXMLElement(volunteersRootElem, Config.s_volunteers);
    }
    public void Delete(int id)
    {
        XElement volunteersRootElem = XMLTools.LoadListFromXMLElement(Config.s_volunteers);
        XElement? volunteerElement = volunteersRootElem.Elements()
            .FirstOrDefault(v => (int?)v.Element("Id") == id) ?? throw new DalDoesNotExistException($"Volunteer with ID {id} not found.");
        volunteerElement.Remove();
        XMLTools.SaveListToXMLElement(volunteersRootElem, Config.s_volunteers);
    }

    public void DeleteAll()
    {
        XElement newRootElement = new("ArrayOfVolunteer");
        XMLTools.SaveListToXMLElement(newRootElement, Config.s_volunteers);
    }

    public IEnumerable<Volunteer> ReadAll(Func<Volunteer, bool>? filter = null)
    {
        XElement volunteersRootElem = XMLTools.LoadListFromXMLElement(Config.s_volunteers);
        var volunteers = volunteersRootElem.Elements()
            .Select(e => GetVolunteer(e));

        return filter == null ? volunteers : volunteers.Where(filter);
    }

    public Volunteer? Read(Func<Volunteer, bool> filter)
    {
        return ReadAll().FirstOrDefault(filter);
    }
}
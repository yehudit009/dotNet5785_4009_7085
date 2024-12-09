using Dal;
using DalApi;
using DO;

/// <summary>
/// Implementing CRUD functions for Volunteer entity
/// </summary>
internal class VolunteerImplementation : IVolunteer
{
    // Adds a new volunteer to the data source.
    public void Create(Volunteer item)
    {
        if (Read(item.VolunteerId) is not null)
            throw new DalAlreadyExistsException($"Volunteer with ID={item.VolunteerId} already exists");
        DataSource.Volunteers.Add(item);
    }

    // Deletes a volunteer from the data source by ID.
    public void Delete(int id)
    {
        Volunteer? TempVol = Read(id);
        if (TempVol == null)
        {
            throw new DalDoesNotExistException($"Volunteer with ID={id} does not exists");
        }
        else
        {
            DataSource.Volunteers.Remove(TempVol);
        }
    }

    // Removes all volunteers from the data source.
    public void DeleteAll()
    {
        if (DataSource.Volunteers.Count > 0)
        {
            DataSource.Volunteers.Clear();
        }
    }

    // Reads and returns a volunteer by ID.
    public Volunteer? Read(int id)
    {
        Volunteer? TempVol = DataSource.Volunteers.FirstOrDefault(obj => obj.VolunteerId == id);
        return TempVol;
    }

    // Reads and returns the first volunteer that matches a given filter condition.
    public Volunteer? Read(Func<Volunteer, bool> filter) // Stage 2
    {
        return DataSource.Volunteers.FirstOrDefault(filter);
    }

    // Reads and returns all volunteers or a filtered list of volunteers.
    public IEnumerable<Volunteer> ReadAll(Func<Volunteer, bool>? filter = null) // Stage 2
        => filter == null
            ? DataSource.Volunteers.Select(item => item)
            : DataSource.Volunteers.Where(filter);

    // Updates a volunteer by deleting and recreating the record with updated data.
    public void Update(Volunteer item)
    {
        Delete(item.VolunteerId);
        Create(item);
    }
}

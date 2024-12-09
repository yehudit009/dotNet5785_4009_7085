namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class VolunteerImplementation : IVolunteer
{
    public void Create(Volunteer item)
    {
        //for entities with normal id (not auto id)
        if (Read(item.VolunteerId) is not null)
            throw new DalAlreadyExistsException($"Volunteer with ID={item.VolunteerId} already exists");
        DataSource.Volunteers.Add(item);
    }

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

    public void DeleteAll()
    {
        if (DataSource.Volunteers.Count > 0)
        {
            DataSource.Volunteers.Clear();
        }
    }

    public Volunteer? Read(int id)
    {
        Volunteer? TempVol = DataSource.Volunteers.FirstOrDefault(obj => obj.VolunteerId == id);
        return TempVol;
    }

    public Volunteer? Read(Func<Volunteer, bool> filter) //stage 2
    {
        return DataSource.Volunteers.FirstOrDefault(filter);
    }
    public IEnumerable<Volunteer> ReadAll(Func<Volunteer, bool>? filter = null) //stage 2
        => filter == null
            ? DataSource.Volunteers.Select(item => item)
            : DataSource.Volunteers.Where(filter);
    public void Update(Volunteer item)
    {
        Delete(item.VolunteerId);
        Create(item);
    }
}
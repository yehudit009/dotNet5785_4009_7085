namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class VolunteerImplementation : IVolunteer
{
    public void Create(Volunteer item)
    {
        if (Read(item.VolunteerId) == null)
        {
            DataSource.Volunteers.Add(item);
        }
        else
        {
            throw new NotImplementedException("An object of type Volunteer with such ID already exists");
        }
    }

    public void Delete(int id)
    {
        Volunteer? TempVol = Read(id);
        if (TempVol == null)
        {
            throw new NotImplementedException("An object of type Volunteer with such ID does not exist");
        }
        else
        {
            DataSource.Volunteers.Remove(TempVol);
        }
    }

    public void DeleteAll()
    {
        DataSource.Volunteers.Clear();
    }

    public Volunteer? Read(int id)
    {
        Volunteer? TempVol = DataSource.Volunteers.SingleOrDefault(obj => obj.VolunteerId == id);
        return TempVol;
    }

    public List<Volunteer> ReadAll()
    {
        return new List<Volunteer>(DataSource.Volunteers);
    }

    public void Update(Volunteer item)
    {
        Delete(item.VolunteerId);
        Create(item);
    }
}
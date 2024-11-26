namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class VolunteerImplementation : IVolunteer
{
    public void Create(Volunteer item)
    {
        Volunteer? TempVol = DataSource.Volunteers.SingleOrDefault(obj => obj.VolunteerId == item.VolunteerId);
        if (TempVol == null)
        {
            DataSource.Volunteers.Add(item);
        }
        else
        {
            throw new NotImplementedException($"An Volunteer with ID={item.VolunteerId} allready exist");
        }
    }

    public void Delete(int id)
    {
        Volunteer? TempVol = Read(id);
        DataSource.Volunteers.Remove(TempVol);
    }

    public void DeleteAll()
    {
        DataSource.Volunteers.Clear();
    }

    public Volunteer? Read(int id)
    {
        Volunteer? TempVol = DataSource.Volunteers.SingleOrDefault(obj => obj.VolunteerId == id);
        if (TempVol == null)
        {
            throw new NotImplementedException($"An Volunteer with such ID={id} does not exist");
        }
        else
        {
            return TempVol;
        }
    }

    public List<Volunteer> ReadAll()
    {
        Console.WriteLine("hi");
        return new List<Volunteer>(DataSource.Volunteers);
    }

    public void Update(Volunteer item)
    {
        Delete(item.VolunteerId);
        Create(item);
    }
}
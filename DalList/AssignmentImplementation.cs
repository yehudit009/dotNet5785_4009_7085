namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class AssignmentImplementation : IAssignment
{
    public void Create(Assignment item)
    {
        int newId = Config.NextAssignmentId;
        Assignment CopyItem = item with { AssignmentId = newId };
        DataSource.Assignments.Add(CopyItem);
    }
    public void Delete(int id)
    {
        Assignment? TempVol = Read(id);
        if (TempVol == null)
        {
            throw new NotImplementedException($"An Assignment with ID={id} does not exist");
        }
        else
        {
            DataSource.Assignments.Remove(TempVol);
        }
    }

    public void DeleteAll()
    {
        if (DataSource.Assignments.Count > 0)
        {
            DataSource.Assignments.Clear();
        }
    }

    public Assignment? Read(int id)
    {
        Assignment? TempVol = DataSource.Assignments.SingleOrDefault(obj => obj.AssignmentId == id);
        return TempVol;
    }

    public List<Assignment> ReadAll()
    {
        return new List<Assignment>(DataSource.Assignments);
    }

    public void Update(Assignment item)
    {
        Delete(item.AssignmentId);
        Create(item);
    }
}

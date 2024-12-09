namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

/// <summary>
/// Implementing CRUD functions for Assignmant entity
/// </summary>
internal class AssignmentImplementation : IAssignment
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
            throw new DalDoesNotExistException($"Assignmant with ID={id} does not exists");
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
        Assignment? TempVol = DataSource.Assignments.FirstOrDefault(obj => obj.AssignmentId == id);
        return TempVol;
    }
    public Assignment? Read(Func<Assignment, bool> filter) //stage 2
    {
        return DataSource.Assignments.FirstOrDefault(filter);
    }
    public IEnumerable<Assignment> ReadAll(Func<Assignment, bool>? filter = null) //stage 2
        => filter == null
            ? DataSource.Assignments.Select(item => item)
            : DataSource.Assignments.Where(filter);

    public void Update(Assignment item)
    {
        Delete(item.AssignmentId);
        Create(item);
    }
}

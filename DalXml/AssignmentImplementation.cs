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
        List<Assignment> Assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments);
        int newId = Config.NextAssignmentId;
        Assignment CopyItem = item with { AssignmentId = newId };
        Assignments.Add(CopyItem);
        XMLTools.SaveListToXMLSerializer(Assignments, Config.s_assignments);

        // List<Assignment> assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments_xml);
        //if (assignments.Exists(a => a.Id == item.Id))
        //    throw new DalAlreadyExistsException($"Assignment with ID {item.Id} already exists.");

        //assignments.Add(item);
        //XMLTools.SaveListToXMLSerializer(assignments, Config.s_assignments_xml);

    }
    public void Delete(int id)
    {
        List<Assignment> Assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments);
        if (Assignments.RemoveAll(it => it.AssignmentId == id) == 0)
            throw new DalDoesNotExistException($"Assignment with ID={id} does Not exist");
        XMLTools.SaveListToXMLSerializer(Assignments, Config.s_assignments);
    }

    public void DeleteAll()
    {
        XMLTools.SaveListToXMLSerializer(new List<Assignment>(), Config.s_assignments);
    }

    public Assignment? Read(int id)
    {
        List<Assignment> Assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments);
        Assignment? TempVol = Assignments.FirstOrDefault(obj => obj.AssignmentId == id);
        return TempVol;
    }
    public Assignment? Read(Func<Assignment, bool> filter) //stage 2
    {
        List<Assignment> Assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments);
        return Assignments.FirstOrDefault(filter);
    }
    public IEnumerable<Assignment> ReadAll(Func<Assignment, bool>? filter = null){ //stage 2
        List<Assignment> Assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments);
        if (filter == null)
            return Assignments;
        return Assignments.Where(filter);
        }
    public void Update(Assignment item)
    {
        List<Assignment> Assignments = XMLTools.LoadListFromXMLSerializer<Assignment>(Config.s_assignments);
        if (Assignments.RemoveAll(it => it.AssignmentId == item.AssignmentId) == 0)
            throw new DalDoesNotExistException($"Assignment with ID={item.AssignmentId} does Not exist");
        Assignments.Add(item);
        XMLTools.SaveListToXMLSerializer(Assignments, Config.s_assignments);
    }
}

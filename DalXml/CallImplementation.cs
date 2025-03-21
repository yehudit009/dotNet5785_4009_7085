namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementing CRUD functions for Call entity
/// </summary>
internal class CallImplementation : ICall
{
    public void Create(Call item)
    {
        List<Call> Calls = XMLTools.LoadListFromXMLSerializer<Call>(Config.s_calls);
        int newId = Config.NextCallId;
        Call CopyItem = item with { CallId = newId };
        Calls.Add(CopyItem);
        XMLTools.SaveListToXMLSerializer(Calls, Config.s_calls);
    }

    public void Delete(int id)
    {
        List<Call> Calls = XMLTools.LoadListFromXMLSerializer<Call>(Config.s_calls);
        if (Calls.RemoveAll(it => it.CallId == id) == 0)
            throw new DalDoesNotExistException($"Call with ID={id} does Not exist");
        XMLTools.SaveListToXMLSerializer(Calls, Config.s_calls);
    }

    public void DeleteAll()
    {
        XMLTools.SaveListToXMLSerializer(new List<Call>(), Config.s_calls);

    }

    public Call? Read(int id)
    {
        List<Call> Calls = XMLTools.LoadListFromXMLSerializer<Call>(Config.s_calls);
        Call? TempVol = Calls.FirstOrDefault(obj => obj.CallId == id);
        return TempVol;
    }

    public Call? Read(Func<Call, bool> filter) //stage 2
    {
        List<Call> Calls = XMLTools.LoadListFromXMLSerializer<Call>(Config.s_calls);
        return Calls.FirstOrDefault(filter);
    }
    public IEnumerable<Call> ReadAll(Func<Call, bool>? filter = null)
    {
        List<Call> Calls = XMLTools.LoadListFromXMLSerializer<Call>(Config.s_calls);
        if (filter == null)
            return Calls;
        return Calls.Where(filter);
    }

    public void Update(Call item)
    {
        List<Call> Calls = XMLTools.LoadListFromXMLSerializer<Call>(Config.s_calls);
        if (Calls.RemoveAll(it => it.CallId == item.CallId) == 0)
            throw new DalDoesNotExistException($"Call with ID={item.CallId} does Not exist");
        Calls.Add(item);
        XMLTools.SaveListToXMLSerializer(Calls, Config.s_calls);
    }
}

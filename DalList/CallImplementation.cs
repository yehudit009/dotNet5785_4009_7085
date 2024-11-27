namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class CallImplementation : ICall
{
    public void Create(Call item)
    {
        int newId = Config.NextCallId;
        Call CopyItem = item with { CallId = newId };
        DataSource.Calls.Add(CopyItem);
    }
    public void Delete(int id)
    {
        Call? TempVol = Read(id);
        if (TempVol == null)
        {
            throw new NotImplementedException($"An Call with ID={id} does not exist");
        }
        else
        {
            DataSource.Calls.Remove(TempVol);
        }
    }

    public void DeleteAll()
    {
        if (DataSource.Calls.Count > 0)
        {
            DataSource.Calls.Clear();
        }
    }

    public Call? Read(int id)
    {
        Call? TempVol = DataSource.Calls.SingleOrDefault(obj => obj.CallId == id);
        return TempVol;
    }

    public List<Call> ReadAll()
    {
        return new List<Call>(DataSource.Calls);
    }

    public void Update(Call item)
    {
        Delete(item.CallId);
        Create(item);
    }
}
namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class CallImplementation : ICall
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
            throw new DalDoesNotExistException($"Call with ID={id} does not exists");
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
        Call? TempVol = DataSource.Calls.FirstOrDefault(obj => obj.CallId == id);
        return TempVol;
    }
    public Call? Read(Func<Call, bool> filter) //stage 2
    {
        return DataSource.Calls.FirstOrDefault(filter);
    }
    public IEnumerable<Call> ReadAll(Func<Call, bool>? filter = null) //stage 2
        => filter == null
            ? DataSource.Calls.Select(item => item)
            : DataSource.Calls.Where(filter);

    public void Update(Call item)
    {
        Delete(item.CallId);
        Create(item);
    }
}
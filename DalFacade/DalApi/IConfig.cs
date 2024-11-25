namespace DalApi;
public interface IConfig
{
    DateTime Clock { get; set; }//Maintain the system clock.
    TimeSpan RiskRange { get; set; }//Defines the time range from which the call is considered at risk
    void Reset();//Reset all attributes in the entity
}
namespace DalApi;
public interface IConfig
{
    DateTime Clock { get; set; }//Maintain the system clock.
 
    void Reset();//Reset all attributes in the entity
}
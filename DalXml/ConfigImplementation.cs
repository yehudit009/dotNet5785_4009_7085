namespace Dal;
using DalApi;

/// <summary>
/// Implementation of the IConfig interface for managing configuration settings.
/// </summary>
internal class ConfigImplementation : IConfig
{
    /// <summary>
    /// Gets or sets the current clock setting.
    /// </summary>
    public DateTime Clock
    {
        get => Config.Clock;
        set => Config.Clock = value;
    }

    /// <summary>
    /// Resets all configuration settings to their default state.
    /// </summary>
    public void Reset()
    {
        Config.Reset();
    }
}

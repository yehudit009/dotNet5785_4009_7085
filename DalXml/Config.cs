namespace Dal;
internal static class Config
{
    internal const string s_data_config = "data-config.xml";
    internal const string s_volunteers = "volunteers.xml";
    internal const string s_assignments = "assignments.xml";
    internal const string s_calls = "calls.xml";

    internal static int NextCallId
    {
        get => XMLTools.GetAndIncreaseConfigIntVal(s_data_config, "NextCallId");
        private set => XMLTools.SetConfigIntVal(s_data_config, "NextCallId", value);
    }
    internal static int NextAssignmentId
    {
        get => XMLTools.GetAndIncreaseConfigIntVal(s_data_config, "NextAssignmentId");
        private set => XMLTools.SetConfigIntVal(s_data_config, "NextAssignmentId", value);
    }
    internal static DateTime Clock
    {
        get => XMLTools.GetConfigDateVal(s_data_config, "Clock");
        set => XMLTools.SetConfigDateVal(s_data_config, "Clock", value);
    }
    
    internal static void Reset()
    {
        NextCallId = 0;
        NextAssignmentId = 0;
        Clock = DateTime.Now;
    }
}

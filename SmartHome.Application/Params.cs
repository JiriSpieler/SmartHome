namespace SmartHome.Application
{
    public interface IParams
    {
        Configuration Cfg { get; }
        string Version { get; }
    }

    public class Params : IParams
    {
        public Params()
        {
            cfg= new Configuration();
            jobs = new Jobs();
        }

        private Configuration cfg;
        public Configuration Cfg => cfg;

        private Jobs jobs;
        public Jobs Jobs => jobs;
        public string Version { get; private set; }
    }

    public class Configuration
    {
        public string AppName { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public Cors Cors { get; set; } = new Cors();
    }

    public class Jobs
    {
        public ThermoRuleStatus? ThermoRuleStatus { get; set; }
    }

    public class ThermoRuleStatus
    {
        public int StartHour { get; set; }

        public int StartMinute { get; set; }
        public int Period { get; set; }
    }

    public class Cors
    {
        public bool Enabled { get; set; } = false;
        public string? Origin { get; set; }
    }
}

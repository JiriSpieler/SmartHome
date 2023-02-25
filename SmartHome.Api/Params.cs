namespace SmartHome.Api
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
        }

        private Configuration cfg;
        public Configuration Cfg => cfg;
        public string Version { get; private set; }
    }

    public class Configuration
    {
        public string AppName { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public Cors Cors { get; set; } = new Cors();
    }

    public class Cors
    {
        public bool Enabled { get; set; } = false;
        public string? Origin { get; set; }
    }
}

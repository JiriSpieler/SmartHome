namespace SmartHome.Application.Services
{
    public class ParamService : IParamService
    {
        public ParamService(Params parameters) => Parameters = parameters;

        public Params Parameters { get; }
    }
}

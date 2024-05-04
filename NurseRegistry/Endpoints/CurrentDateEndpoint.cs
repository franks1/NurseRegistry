using Wolverine.Http;

namespace NurseRegistry.Endpoints;


public class CurrentDateEndpoint
{

    [WolverineGet("/api/currentdate")]
    public string Get() => $"{DateTime.UtcNow}";

}
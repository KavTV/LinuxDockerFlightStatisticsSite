namespace FlightCrashSite.Services;

public interface IFlightCrashService
{

}

public class FlightCrashService : IFlightCrashService
{
	private readonly string path;

	public FlightCrashService(string path)
	{
		this.path = path;
	}

	public void Initalize()
	{
	}
}

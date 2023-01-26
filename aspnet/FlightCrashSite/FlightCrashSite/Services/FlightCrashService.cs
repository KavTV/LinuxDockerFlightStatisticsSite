using FlightCrashSite.Models;

namespace FlightCrashSite.Services;

public interface IFlightCrashService
{

}

public class FlightCrashService : IFlightCrashService
{
	private readonly string path;
	private List<FlightCrashReport> flightCrashReports = new List<FlightCrashReport>();

	public FlightCrashService(string path)
	{
		this.path = path;
	}

	public FlightCrashService Initalize()
	{
		flightCrashReports = File.ReadAllLines("./flight-data.csv")
							   .Skip(1)
							   .Select(v => FlightCrashReport.FromCsv(v))
							   .ToList();
		return this;
	}

	public List<FlightCrashReport> GetByLocation(string location)
	{
		return flightCrashReports.FindAll(f => f.Location == location).ToList();
	}
}

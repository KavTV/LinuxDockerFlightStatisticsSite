using CsvHelper;
using FlightCrashSite.Models;
using System.Globalization;

namespace FlightCrashSite.Services;

public interface IFlightCrashService
{
	FlightYearlyCrashReport GetFlightYearlyCrashReport(int year);
	List<FlightYearlyCrashReport> GetFlightYearlyCrashReports(int startYear, int endYear);
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
		//using (var reader = new StreamReader(path))
		//using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
		//{
		//	flightCrashReports = csv.GetRecords<FlightCrashReport>().ToList();
		//}

		flightCrashReports = File.ReadAllLines("./flight-data.csv")
							   .Skip(1)
							   .Select(v => FlightCrashReport.FromCsv(v))
							   .ToList();
		return this;
	}

	public List<FlightYearlyCrashReport> GetFlightYearlyCrashReports(int startYear, int endYear)
	{
		List<FlightYearlyCrashReport> flightYearlyCrashReports = new List<FlightYearlyCrashReport>();
		for (int year = startYear; year <= endYear; year++)
		{
			flightYearlyCrashReports.Add(GetFlightYearlyCrashReport(year));
		}
		return flightYearlyCrashReports;
	}

	public FlightYearlyCrashReport GetFlightYearlyCrashReport(int year)
	{
		List<FlightCrashReport> flightYearlyCrashReports = flightCrashReports.FindAll(f => f.Date.Year == year);
		FlightYearlyCrashReport flightYearlyCrashReport = new()
		{
			Crashes = flightYearlyCrashReports.Count,
			Year = year
		};

		foreach (FlightCrashReport flightCrashReport in flightYearlyCrashReports)
		{
			flightYearlyCrashReport.Deaths += flightCrashReport.Fatalities;
		}
		return flightYearlyCrashReport;
	}
}

using CsvHelper;
using FlightCrashSite.Models;
using System.Globalization;

namespace FlightCrashSite.Services;

public interface IFlightCrashService
{
	List<FlightOperatorCrashReport> GetAllFlightOperatorCrashReports();
	List<FlightCrashReport> GetFlightCrashReportsByOperator(string flightType);
	FlightOperatorCrashReport GetFlightOperatorReport(string flightOperator);
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
		flightCrashReports = File.ReadAllLines("./flight-data.csv")
							   .Skip(1)
							   .Select(v => FlightCrashReport.FromCsv(v))
							   .ToList();
		return this;
	}

	public List<FlightCrashReport> GetFlightCrashReportsByOperator(string flightOperator)
	{
		return flightCrashReports.FindAll(f => f.Operator == flightOperator).ToList();
	}

	public List<FlightOperatorCrashReport> GetAllFlightOperatorCrashReports()
	{
		List<string> flightOperators = flightCrashReports.Select(f => f.Operator).Distinct().ToList();
		List<FlightOperatorCrashReport> flightOperatorCrashReports = new List<FlightOperatorCrashReport>();
		foreach(string flightOperator in flightOperators)
		{
			flightOperatorCrashReports.Add(GetFlightOperatorReport(flightOperator));
		}
		return flightOperatorCrashReports;
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

	public FlightOperatorCrashReport GetFlightOperatorReport(string flightOperator)
	{
		List<FlightCrashReport> flightCrashReports = this.flightCrashReports.FindAll(f => f.Operator == flightOperator);
		FlightOperatorCrashReport flightOperatorCrashReport = new()
		{
			Crashes = flightCrashReports.Count,
			Operator = flightOperator
		};
		foreach (FlightCrashReport flightCrashReport in flightCrashReports)
		{
			flightOperatorCrashReport.Deaths += flightCrashReport.Fatalities;
		}
		return flightOperatorCrashReport;
	}
}

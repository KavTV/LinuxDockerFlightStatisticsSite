﻿namespace FlightCrashSite.Models;

public class FlightCrashReport
{
	public DateOnly? Date { get; set; }
	public TimeOnly? Time { get; set; }
	public string? Location { get; set; } 
	public string? Operator { get; set; } 
	public string? Flight { get; set; } 
	public string? Route { get; set; }
	public string? Type { get; set; } 
	public string? CnIn { get; set; } 
	public string? Aboard { get; set; } 
	public string? Fatalities { get; set; }
	public string? Ground { get; set; }
	public string? Summary { get; set; } 

	public static FlightCrashReport FromCsv(string csvLine)
	{
		string[] values = csvLine.Split(',');
		FlightCrashReport flightCrashReport = new FlightCrashReport();
		try
		{
			if (!string.IsNullOrWhiteSpace(values[1]))
			{
				flightCrashReport.Date = DateOnly.ParseExact(values[0], "MM/dd/yyyy");
			}
		}
		catch { }
		try
		{
			if (!string.IsNullOrWhiteSpace(values[1]))
			{
				flightCrashReport.Time = TimeOnly.Parse(values[1]);
			}
		}
		catch { }
		flightCrashReport.Location = values[2];
		flightCrashReport.Operator = values[3];
		flightCrashReport.Flight = values[4];
		flightCrashReport.Route = values[5];
		flightCrashReport.Type = values[6];
		flightCrashReport.CnIn = values[7];
		flightCrashReport.Aboard = values[8];
		flightCrashReport.Fatalities = values[9];
		flightCrashReport.Ground = values[10];
		flightCrashReport.Summary = values[11];
		return flightCrashReport;
	}
}
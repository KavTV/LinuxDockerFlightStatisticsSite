namespace FlightCrashSite.Models;

public class FlightCrashReport
{
	public DateOnly Date { get; set; }
	public TimeOnly Time { get; set; }
	public string Location { get; set; }
	public string Operator { get; set; }
	public string Flight { get; set; }
	public string Route { get; set; }
	public string Type { get; set; }
	public string Registration { get; set; }
	public string CnIn { get; set; }
	public int Aboard { get; set; }
	public int Fatalities { get; set; }
	public string Ground { get; set; }
	public string Summary { get; set; }

	public static FlightCrashReport FromCsv(string csvLine)
	{
		//if (csvLine.Contains("Akron exploded"))
		//{
		//	int a = 0;
		//}
		string[] values = SplitCsv(csvLine);
		FlightCrashReport flightCrashReport = new FlightCrashReport();
		if (!string.IsNullOrWhiteSpace(values[0]))
		{
			flightCrashReport.Date = DateOnly.ParseExact(values[0], "MM/dd/yyyy");
		}
		if (!string.IsNullOrWhiteSpace(values[1]))
		{
			//flightCrashReport.Time = TimeOnly.Parse(values[1]);
		}
		flightCrashReport.Location = values[2];
		flightCrashReport.Operator = values[3];
		flightCrashReport.Flight = values[4];
		flightCrashReport.Route = values[5];
		flightCrashReport.Type = values[6];
		flightCrashReport.Registration = values[7];
		flightCrashReport.CnIn = values[8];
		if (int.TryParse(values[9], out int aboard))
		{
			flightCrashReport.Aboard = aboard;
		}
		if (int.TryParse(values[10], out int fatalities))
		{
			flightCrashReport.Fatalities = fatalities;
		}
		flightCrashReport.Ground = values[11];
		flightCrashReport.Summary = values[12];
		return flightCrashReport;
	}

	private static string[] SplitCsv(string csvLine)
	{
		string current = "";
		List<string> values = new List<string>();
		bool isStr = false;
		foreach (char c in csvLine)
		{
			if (c == '\"')
			{
				isStr = !isStr;
			}
			if (c == ',' && !isStr)
			{
				values.Add(current);
				current = "";
				continue;
			}
			current += c;
		}
		values.Add(current);
		return values.ToArray();
	}
}

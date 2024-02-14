namespace ACMEControl.Middleware;

public static class Middleware
{
    public static void SendTelemetry(string telemetry)
    {
        System.Console.WriteLine("telemetry: " + telemetry);
    }
}

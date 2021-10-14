namespace SampleScenario.DataProviders
{
    public interface IMonitoringDataRepository
	{
		MonitoringData[] GetLastHourData();
	}
}

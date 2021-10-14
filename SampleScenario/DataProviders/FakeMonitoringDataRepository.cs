using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleScenario.DataProviders
{
	public class FakeMonitoringDataRepository : IMonitoringDataRepository
	{
		private static Random _random = new Random();

		public MonitoringData[] GetLastHourData()
		{
			var fakeData = new List<MonitoringData>();

			var startingTime = DateTime.Now;

			for (int d = 0; d < 10; ++d)
			{
				fakeData.Add(new MonitoringData()
				{
					Metric = Metrics.CPUPercentage,
					MetricValue = _random.NextDouble() * 100,
					CollectionTime = startingTime.AddMinutes(d)
				});
			}

			for (int d = 0; d < 10; ++d)
			{
				fakeData.Add(new MonitoringData()
				{
					Metric = Metrics.UsedRAMGigaBytes,
					MetricValue = _random.NextDouble() * 8,
					CollectionTime = startingTime.AddMinutes(d)
				});
			}

			return fakeData.ToArray();
		}
	}
}

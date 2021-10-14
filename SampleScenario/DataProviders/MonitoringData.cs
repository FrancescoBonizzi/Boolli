using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleScenario.DataProviders
{
	public class MonitoringData
	{
		public Metrics Metric { get; set; }
		public double MetricValue { get; set; }
		public DateTime CollectionTime { get; set; }
	}
}

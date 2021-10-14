using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleScenario.Alerts
{
    public class Alert
    {
		public string Message { get; set; }
		public DateTime GenerationDate { get; set; }
		public AlertGravity AlertGravity { get; set; }
		public string GeneratingRuleName { get; set; }
	}
}

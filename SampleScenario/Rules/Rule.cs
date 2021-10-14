using SampleScenario.Alerts;
using SampleScenario.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleScenario.Rules
{
    public class Rule
    {
		public string RuleName { get; set; }
		public string BooleanExpression { get; set; }
		public AlertGravity ResultingAlertGravity { get; set; }
		public string MessageFormat { get; set; }
		public int TimeFrameMinutes { get; set; }
		public DataEvaluationFunctionDescription[] DataEvaluationFunctionDescription { get; set; }
	}
}

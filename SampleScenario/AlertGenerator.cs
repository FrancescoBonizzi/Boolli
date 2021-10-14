using Boolli;
using SampleScenario.Alerts;
using SampleScenario.DataProviders;
using SampleScenario.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleScenario
{
    public class AlertGenerator
	{
		private readonly Rule[] _alertGenerationRules;

		public AlertGenerator(Rule[] alertGenerationRules)
		{
			_alertGenerationRules = alertGenerationRules;
		}

		public List<Alert> GenerateAlerts(MonitoringData[] monitoringData)
		{
			var alerts = new List<Alert>();
			var boolli = new Evaluator();

			foreach (var rule in _alertGenerationRules)
			{
				// I need object for String.Format
				var lastValues = new Dictionary<Metrics, MonitoringData>();

				var namedBooleanFunctions = rule.DataEvaluationFunctionDescription.Select(d => new NamedBooleanFunction(
					d.Metric.ToString(),
					() =>
					{
						(bool IsCritical, MonitoringData data) = ValueCritical(
							monitoringData,
							DateTime.Now.AddMinutes(-rule.TimeFrameMinutes),
							d.Metric,
							d.Threshold);

						if (IsCritical && data != null)
						{
							lastValues[d.Metric] = data;
						}

						return IsCritical;
					})).ToArray();

				bool alertShouldBeGenerated = boolli.EvaluateFuncOfBoolExpression(
					rule.BooleanExpression,
					namedBooleanFunctions);

				if (alertShouldBeGenerated)
				{
					var stringFormatParameters = new List<object>();
					foreach (var lastValue in lastValues)
					{
						stringFormatParameters.Add((int)lastValue.Value.MetricValue);
					}

					if (stringFormatParameters.Count < Enum.GetNames(typeof(Metrics)).Length)
                    {
						for (int i = 0; i < Enum.GetNames(typeof(Metrics)).Length; ++i)
							stringFormatParameters.Add("-");
                    }

					stringFormatParameters.Add(lastValues.Values.OrderByDescending(v => v.CollectionTime).FirstOrDefault().CollectionTime);

					alerts.Add(new Alert()
					{
						GeneratingRuleName = rule.RuleName,
						AlertGravity = rule.ResultingAlertGravity,
						GenerationDate = DateTime.Now,
						Message = string.Format(rule.MessageFormat, stringFormatParameters.ToArray())
					});
				}
			}

			return alerts;
		}

		private (bool IsCritical, MonitoringData Data) ValueCritical(
			MonitoringData[] monitoringData,
			DateTime startingDate,
			Metrics metric,
			double threshold)
		{
			foreach (var data in monitoringData
				.Where(d => d.CollectionTime > startingDate)
				.OrderByDescending(d => d.CollectionTime))
			{
				if (data.Metric == metric && data.MetricValue > threshold)
				{
					return (true, data);
				}
			}

			return (false, null);
		}
	}
}

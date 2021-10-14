using SampleScenario.Alerts;
using SampleScenario.DataProviders;
using SampleScenario.Rules;
using System;

namespace SampleScenario
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleRules = new Rule[]
            {
                new Rule()
                {
                    RuleName = "RAM full and CPU busy last minute",
                    BooleanExpression = $"{Metrics.CPUPercentage} and {Metrics.UsedRAMGigaBytes}",
                    ResultingAlertGravity = AlertGravity.Critical,
                    MessageFormat = "Attention! Last minute CPU ({0}%) and RAM ({1} GB) are very critical! (Last value collection time: {2})",
                    TimeFrameMinutes = 1,
                    DataEvaluationFunctionDescription  = new DataEvaluationFunctionDescription[]
                    {
                        new DataEvaluationFunctionDescription()
                        {
                            Metric = Metrics.CPUPercentage,
                            Threshold = 90
                        },
                        new DataEvaluationFunctionDescription()
                        {
                            Metric = Metrics.UsedRAMGigaBytes,
                            Threshold = 7
                        }
                    }
                },
                new Rule()
                {
                    RuleName = "RAM and CPU will be busy soon",
                    BooleanExpression = $"{Metrics.CPUPercentage} or {Metrics.UsedRAMGigaBytes}",
                    ResultingAlertGravity = AlertGravity.Warning,
                    MessageFormat = "Last hour data: it seems that CPU ({0}%) or RAM ({1} GB) are going to become critical (Last value collection time: {2})",
                    TimeFrameMinutes = 60,
                    DataEvaluationFunctionDescription  = new DataEvaluationFunctionDescription[]
                    {
                        new DataEvaluationFunctionDescription()
                        {
                            Metric = Metrics.CPUPercentage,
                            Threshold = 60
                        },
                        new DataEvaluationFunctionDescription()
                        {
                            Metric = Metrics.UsedRAMGigaBytes,
                            Threshold = 4
                        }
                    }
                }
            };

            // Get data from some monitoring sources
            var monitoringDataRepository = new FakeMonitoringDataRepository();
            var fakeData = monitoringDataRepository.GetLastHourData();

            var alertGenerator = new AlertGenerator(sampleRules);
            var alerts = alertGenerator.GenerateAlerts(fakeData);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Fake data");
            Console.ResetColor();
            foreach (var fakeDataRecord in fakeData)
            {
                Console.WriteLine($"{fakeDataRecord.Metric}: {(int)fakeDataRecord.MetricValue}, {fakeDataRecord.CollectionTime}");
            }

            Console.WriteLine();
            foreach (var alert in alerts)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Alert generated");
                Console.ResetColor();

                Console.WriteLine(
                    $"Rule name: {alert.GeneratingRuleName}" + Environment.NewLine
                    + $"Gravity: {alert.AlertGravity}" + Environment.NewLine
                    + $"Generation date: {alert.GenerationDate}" + Environment.NewLine
                    + $"Message: {alert.Message}");
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}

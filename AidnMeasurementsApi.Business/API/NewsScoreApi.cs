using Aidn.Shared.Models;
using AidnMeasurementsApi.Business.Extensions;
using AidnMeasurementsApi.Domain;

namespace AidnMeasurementsApi.Business.API;

public class NewsScoreApi : INewsScoreApi
{
    public int GetNewsScore(IEnumerable<Measurement> measurements)
    {
        if (measurements is null || !measurements.Any())
        {
            throw new ArgumentException(nameof(measurements));
        }

        return measurements.Select(s => s.Value.Score(s.MeasurementType)).Sum();
    }
}


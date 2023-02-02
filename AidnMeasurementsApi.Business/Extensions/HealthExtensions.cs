using Aidn.Shared.Models;
using AidnMeasurementsApi.Data;

namespace AidnMeasurementsApi.Business.Extensions;

public static class HealthExtensions
{
    public static int Score(this int value, MeasurementType measurementType)
    {
        var ranges = DataHelper.GetData().GetValueOrDefault(measurementType);

        if (ranges is null)
        {
            throw new KeyNotFoundException(nameof(measurementType));
        }

        foreach (var range in from range in ranges
                              let rangeKey = range.Key
                              where value > rangeKey.Min && value <= rangeKey.Max
                              select range)
        {
            return range.Value;
        }

        throw new KeyNotFoundException(value.ToString());
    }
}


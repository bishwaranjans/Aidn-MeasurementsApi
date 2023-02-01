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

        foreach (var range in ranges)
        {
            if (value > range.Min && value <= range.Max)
            {
                return range.Score;
            }
        }

        throw new KeyNotFoundException(value.ToString());
    }
}


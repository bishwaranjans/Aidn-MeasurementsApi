using Aidn.Shared.Models;
using AidnMeasurementsApi.Data.Entities;

namespace AidnMeasurementsApi.Data;

public static class DataHelper
{
    // In real-life scenarios, get it from DB or any cloud storage
    // Starting value is exclusive and Ending value is inclusive
    private static readonly List<HealthRange> TemperatureRanges = new()
    {
        new TemperatureRange(Min: 31, Max: 35, Score: 3),
        new TemperatureRange(Min: 35, Max: 36, Score: 1),
        new TemperatureRange(Min: 36, Max: 38, Score: 0),
        new TemperatureRange(Min: 38, Max: 39, Score: 1),
        new TemperatureRange(Min: 39, Max: 42, Score: 2),
    };

    private static readonly List<HealthRange> HrRanges = new()
    {
        new HrRange(Min: 25, Max: 40, Score: 3),
        new HrRange(Min: 40, Max: 50, Score: 1),
        new HrRange(Min: 50, Max: 90, Score: 0),
        new HrRange(Min: 90, Max: 110, Score: 1),
        new HrRange(Min: 110, Max: 130, Score: 2),
        new HrRange(Min: 130, Max: 220, Score: 3),
    };

    private static readonly List<HealthRange> RrRanges = new()
    {
        new RrRange(Min: 3, Max: 8, Score: 3),
        new RrRange(Min: 8, Max: 11, Score: 1),
        new RrRange(Min: 11, Max: 20, Score: 0),
        new RrRange(Min: 20, Max: 24, Score: 2),
        new RrRange(Min: 24, Max: 60, Score: 3),
    };

    public static Dictionary<MeasurementType, List<HealthRange>> GetData()
    {
        return new Dictionary<MeasurementType, List<HealthRange>> {
            { MeasurementType.TEMP, TemperatureRanges },
            { MeasurementType.HR, HrRanges },
            { MeasurementType.RR, RrRanges },
        };
    }
}


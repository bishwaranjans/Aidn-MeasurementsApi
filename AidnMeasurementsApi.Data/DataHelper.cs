using Aidn.Shared.Models;

namespace AidnMeasurementsApi.Data;

public static class DataHelper
{
    // In real-life scenarios, get it from DB or any cloud storage
    // Starting value is exclusive and Ending value is inclusive
    private static readonly Dictionary<(int Min, int Max), int> TemperatureRanges = new()
    {
        { (31, 35), 3 },
        { (35, 36), 1 },
        { (36, 38), 0 },
        { (38, 39), 1 },
        { (39, 42), 2 },
    };

    private static readonly Dictionary<(int Min, int Max), int> HrRanges = new()
    {
        { (25, 40), 3 },
        { (40, 50), 1 },
        { (50, 90), 0 },
        { (90, 110), 1 },
        { (110, 130), 2 },
        { (130, 220), 3 },
    };

    private static readonly Dictionary<(int Min, int Max), int> RrRanges = new()
    {
        { (3, 8), 3 },
        { (8, 11), 1 },
        { (11, 20), 0 },
        { (20, 24), 2 },
        { (24, 60), 3 }
    };

    // To get the score for a range in O(1)
    public static Dictionary<MeasurementType, Dictionary<(int Min, int Max), int>> GetData()
    {
        return new Dictionary<MeasurementType, Dictionary<(int Min, int Max), int>> {
            { MeasurementType.TEMP, TemperatureRanges },
            { MeasurementType.HR, HrRanges },
            { MeasurementType.RR, RrRanges },
        };
    }
}


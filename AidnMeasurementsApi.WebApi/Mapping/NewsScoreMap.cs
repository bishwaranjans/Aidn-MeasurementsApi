using Aidn.Shared.Models;

namespace AidnMeasurementsApi.WebApi.Mapping;

public static class NewsScoreMap
{
    public static NewsScore Map(this int score)
    {
        return new NewsScore(score);
    }
}


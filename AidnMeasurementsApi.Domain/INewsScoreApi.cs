using Aidn.Shared.Models;

namespace AidnMeasurementsApi.Domain;

public interface INewsScoreApi
{
    int GetNewsScore(IEnumerable<Measurement> measurements);
}


namespace AidnMeasurementsApi.Data.Entities;

public record class RrRange(int Min, int Max, int Score) : HealthRange(Min, Max, Score);


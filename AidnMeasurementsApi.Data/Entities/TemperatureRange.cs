namespace AidnMeasurementsApi.Data.Entities;

public record class TemperatureRange(int Min, int Max, int Score) : HealthRange(Min, Max, Score);

namespace AidnMeasurementsApi.Data.Entities;

public record class HrRange(int Min, int Max, int Score) : HealthRange(Min, Max, Score);

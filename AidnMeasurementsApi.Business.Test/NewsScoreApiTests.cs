using Aidn.Shared.Models;
using AidnMeasurementsApi.Business.API;
using AidnMeasurementsApi.Domain;

namespace AidnMeasurementsApi.Business.Test;

public class NewsScoreApiTests
{
    private INewsScoreApi Api => new NewsScoreApi();

    [Fact]
    public void ValidMeasurements_Success()
    {
        // Arrange
        var measurements = new List<Measurement>
        {
            new() { MeasurementType = MeasurementType.TEMP, Value= 37 },
            new() { MeasurementType = MeasurementType.HR, Value= 60 },
            new() { MeasurementType = MeasurementType.RR, Value= 5 },
        };

        // Act
        var result = Api.GetNewsScore(measurements);

        // Assert      
        Assert.Equal(3, result);
    }

    [Fact]
    public void InValidMeasurementValue_Throws_Exception()
    {
        // Arrange
        var measurements = new List<Measurement>
        {
            new() { MeasurementType = MeasurementType.TEMP, Value= 37 },
            new() { MeasurementType = MeasurementType.HR, Value= 10060 },
            new() { MeasurementType = MeasurementType.RR, Value= 5 },
        };

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => Api.GetNewsScore(measurements));
    }

    [Fact]
    public void InValidMeasurements_Throws_Exception()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => Api.GetNewsScore(new List<Measurement>()));
    }
}


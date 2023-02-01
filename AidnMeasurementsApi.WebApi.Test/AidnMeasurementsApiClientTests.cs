using Aidn.Shared.Models;
using AidnMeasurementsApi.Domain;
using AidnMeasurementsApi.WebApi.Client.Test.Helpers;
using Moq;
using Refit;
using System.Net;

namespace AidnMeasurementsApi.WebApi.Client.Test;

public class AidnMeasurementsApiClientTests : AidnTestWebHost<Program>
{
    private IAidnMeasurementsApiClient Client => RestService.For<IAidnMeasurementsApiClient>(GetClient());

    [Fact]
    public async Task AidnMeasurementsApiClient_GetScore_Success()
    {
        // Arrange
        var measurements = new List<Measurement>
        {
            new Measurement() { MeasurementType = MeasurementType.TEMP, Value= 37 },
            new Measurement() { MeasurementType = MeasurementType.HR, Value= 60 },
            new Measurement() { MeasurementType = MeasurementType.RR, Value= 5 },
        };
       
        var mock = new Mock<INewsScoreApi>(MockBehavior.Strict);
        mock.Setup(x => x.GetNewsScore(It.IsAny<IEnumerable<Measurement>>())).Returns(3);
        ReplaceService(mock.Object);

        // Act
        var result = await Client.Get(measurements);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccessStatusCode);
        Assert.NotNull(result.Content);
        Assert.Equal(3, result.Content.Score);

        mock.Verify(x => x.GetNewsScore(It.IsAny<IEnumerable<Measurement>>()), Times.Once);
        mock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AidnMeasurementsApiClient_InValidData_Problem()
    {
        // Arrange
        var measurements = new List<Measurement>
        {
            new Measurement() { MeasurementType = MeasurementType.TEMP, Value= 37 },
            new Measurement() { MeasurementType = MeasurementType.HR, Value= 19060 },
            new Measurement() { MeasurementType = MeasurementType.RR, Value= 5 },
        };
      
        var mock = new Mock<INewsScoreApi>(MockBehavior.Strict);
        mock.Setup(x => x.GetNewsScore(It.IsAny<IEnumerable<Measurement>>())).Returns(3);
        ReplaceService(mock.Object);

        // Act
        var result = await Client.Get(measurements);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccessStatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        mock.Verify(x => x.GetNewsScore(It.IsAny<IEnumerable<Measurement>>()), Times.Never);
        mock.VerifyNoOtherCalls();
    }
}


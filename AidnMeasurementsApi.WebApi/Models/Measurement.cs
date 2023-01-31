using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AidnMeasurementsApi.WebApi;

public class Measurement
{
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MeasurementType MeasurementType { get; set; }

    [Required]
    [Range(0, double.PositiveInfinity, ErrorMessage = "The field {0} must be greater than {1}.")]
    public double Value { get; set; }
}


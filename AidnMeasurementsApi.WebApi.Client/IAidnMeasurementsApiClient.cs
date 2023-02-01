using Aidn.Shared.Models;
using Refit;

namespace AidnMeasurementsApi.WebApi.Client;

public interface IAidnMeasurementsApiClient
{
    [Post("/NewsScore")]
    Task<IApiResponse<NewsScore>> Get([Body] MeasurementsModel measurementsModel);
}

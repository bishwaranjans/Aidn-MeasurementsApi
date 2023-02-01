using Aidn.Shared.Models;
using Aidn.Shared.Validation;
using AidnMeasurementsApi.Domain;
using AidnMeasurementsApi.WebApi.Helpers;
using AidnMeasurementsApi.WebApi.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AidnMeasurementsApi.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class NewsScoreController : ControllerBase
{
    private readonly INewsScoreApi _newsScoreApi;

    public NewsScoreController(INewsScoreApi newsScoreApi) => _newsScoreApi = newsScoreApi;

    [HttpPost]
    public ActionResult<NewsScore> Post([FromBody] MeasurementsModel measurementsModel)
    {
        var (isValid, validationResults) = AidnValidator.TryValidateObjects(measurementsModel.Measurements);

        if (!isValid)
        {
            return ValidationProblem(ModelState.WithError(validationResults));
        }

        return Ok(_newsScoreApi.GetNewsScore(measurementsModel.Measurements).Map());
    }
}


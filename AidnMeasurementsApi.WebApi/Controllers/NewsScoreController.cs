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
    [HttpPost]
    public async Task<ActionResult<NewsScore>> Post([FromBody] MeasurementsModel measurementsModel)
    {
        return new NewsScore(Score: measurementsModel.Measurements.Select(s => s.Value).Sum());
    }
}


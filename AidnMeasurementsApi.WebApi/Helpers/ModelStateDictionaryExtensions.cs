using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace AidnMeasurementsApi.WebApi.Helpers;

internal static class ModelStateDictionaryExtensions
{
    public static ModelStateDictionary WithError(this ModelStateDictionary modelState, List<ValidationResult> validationResults)
    {
        foreach (var errorMessage in validationResults.Select(s => s.ErrorMessage).ToHashSet())
        {
            modelState.AddModelError(Random.Shared.Next().ToString(), errorMessage!);
        }

        return modelState;
    }
}



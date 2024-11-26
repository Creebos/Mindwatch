using KR.Hanyang.Mindwatch.Application.Results;
using Microsoft.AspNetCore.Mvc;

namespace KR.Hanyang.Mindwatch.Api.Helpers
{
    public static class ControllerBaseExtensions
    {
        /// <summary>
        /// Maps an OperationResult to an appropriate IActionResult.
        /// </summary>
        public static IActionResult ToActionResult<T>(this ControllerBase controller, OperationResult<T> result)
        {
            return result.Type switch
            {
                OperationResultType.Success => controller.Ok(result.ResultValue),
                OperationResultType.NotFound => controller.NotFound(),
                OperationResultType.Invalid => controller.BadRequest(result.ValidationErrors),
                _ => controller.StatusCode(500, "An unexpected error occurred.")
            };
        }
    }
}

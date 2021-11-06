using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Extentions
{
    public class CustomBaseController : ControllerBase
    {
        public static IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

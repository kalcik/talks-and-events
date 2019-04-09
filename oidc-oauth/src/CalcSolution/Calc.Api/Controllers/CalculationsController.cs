using System.Security.Claims;
using Calc.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalculationsController : ControllerBase
    {
        [HttpPost]
        [Route("Add")]
        public ActionResult<OperationResponseModel> Add([FromBody] OperationRequestModel operationRequestModel) =>
            new OperationResponseModel
            {
                Result = operationRequestModel.Number1 + operationRequestModel.Number2,
                OperationRequestedBy = GetUserNameFromContext()
            };

        private string GetUserNameFromContext() => HttpContext.User.Identity.Name ?? "unknown";
    }
}
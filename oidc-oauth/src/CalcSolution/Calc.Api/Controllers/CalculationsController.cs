using System;
using Calc.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        [Authorize(Roles = Roles.Basic)]
        [HttpPost]
        [Route("Add")]
        public ActionResult<OperationResponseModel> Add([FromBody] BasicOperationRequestModel basicOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 + basicOperationRequestModel.Number2,
                OperationRequestedBy = GetUserNameFromContext()
            };

        [Authorize(Roles = Roles.Basic)]
        [HttpPost]
        [Route("Sub")]
        public ActionResult<OperationResponseModel> Subtraction([FromBody] BasicOperationRequestModel basicOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 - basicOperationRequestModel.Number2,
                OperationRequestedBy = GetUserNameFromContext()
            };

        [Authorize(Roles = Roles.Basic)]
        [HttpPost]
        [Route("Div")]
        public ActionResult<OperationResponseModel> Division([FromBody] BasicOperationRequestModel basicOperationRequestModel)
        {
            if (basicOperationRequestModel.Number2 == 0) { return BadRequest("Division by zero"); }

            return new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 / basicOperationRequestModel.Number2,
                OperationRequestedBy = GetUserNameFromContext()
            };
        }

        [Authorize(Roles = Roles.Basic)]
        [HttpPost]
        [Route("Mul")]
        public ActionResult<OperationResponseModel> Multiplication(
            [FromBody] BasicOperationRequestModel basicOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 * basicOperationRequestModel.Number2,
                OperationRequestedBy = GetUserNameFromContext()
            };

        [Authorize(Roles = Roles.Advanced)]
        [HttpPost]
        [Route("Sqr")]
        public ActionResult<OperationResponseModel>
            Square([FromBody] AdvancedOperationRequestModel advancedOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = Math.Sqrt(advancedOperationRequestModel.Number),
                OperationRequestedBy = GetUserNameFromContext()
            };

        [Authorize(Roles = Roles.Advanced)]
        [HttpPost]
        [Route("Pwr")]
        public ActionResult<OperationResponseModel>
            PowerOfTwo([FromBody] AdvancedOperationRequestModel advancedOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = Math.Pow(advancedOperationRequestModel.Number, 2),
                OperationRequestedBy = GetUserNameFromContext()
            };

        private string GetUserNameFromContext() => HttpContext.User.Identity.Name ?? "unknown";
    }
}
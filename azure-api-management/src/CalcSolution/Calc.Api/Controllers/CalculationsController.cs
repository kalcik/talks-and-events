using System;
using Calc.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        /// <summary>
        /// Calculate addition of two numbers.
        /// </summary>
        [HttpPost]
        [Route("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<OperationResponseModel> Add([FromBody] BasicOperationRequestModel basicOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 + basicOperationRequestModel.Number2
            };

        /// <summary>
        /// Calculate subtraction of two numbers.
        /// </summary>
        [HttpPost]
        [Route("Sub")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<OperationResponseModel> Subtraction([FromBody] BasicOperationRequestModel basicOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 - basicOperationRequestModel.Number2
            };

        /// <summary>
        /// Calculate division of two numbers.
        /// </summary>
        /// <response code="404">Returns when division with zero.</response>  
        [HttpPost]
        [Route("Div")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OperationResponseModel), 200)]
        public ActionResult<OperationResponseModel> Division([FromBody] BasicOperationRequestModel basicOperationRequestModel)
        {
            if (basicOperationRequestModel.Number2 == 0) { return BadRequest("Division by zero"); }

            return new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 / basicOperationRequestModel.Number2
            };
        }

        /// <summary>
        /// Calculate multiplication of two numbers.
        /// </summary>
        [HttpPost]
        [Route("Mul")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<OperationResponseModel> Multiplication(
            [FromBody] BasicOperationRequestModel basicOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = basicOperationRequestModel.Number1 * basicOperationRequestModel.Number2
            };

        /// <summary>
        /// Calculate value's square.
        /// </summary>
        [HttpPost]
        [Route("Sqr")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<OperationResponseModel>
            Square([FromBody] AdvancedOperationRequestModel advancedOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = Math.Sqrt(advancedOperationRequestModel.Number)
            };

        /// <summary>
        /// Calculate value's power of two.
        /// </summary>
        [HttpPost]
        [Route("Pwr")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<OperationResponseModel>
            PowerOfTwo([FromBody] AdvancedOperationRequestModel advancedOperationRequestModel) =>
            new OperationResponseModel
            {
                Result = Math.Pow(advancedOperationRequestModel.Number, 2)
            };
    }
}
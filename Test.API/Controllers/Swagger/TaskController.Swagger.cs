using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace Test.API.Controllers
{
    /// <summary>
    /// Tasks management controller
    /// </summary>
    [Consumes("application/json")]
    [Produces("application/json")]
    public partial class TaskController : ControllerBase
    {
        /// <summary>
        /// create new task object
        /// </summary>
        /// <returns></returns>
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(Guid))]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status202Accepted)]
        public partial Task<IActionResult> CreateTaskAsync();


        /// <summary>
        /// get task object by id
        /// </summary>
        /// <param name="id">task id Guid</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public partial Task<IActionResult> GetTaskAsync(Guid id);
    }
}

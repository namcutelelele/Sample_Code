using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkingSpace_BusinessObject.Models;
using WorkingSpace_DataAccessLayer.DataLayer;
using WorkingSpace_Services;
using ExceptionHandling;
using System.Net;


namespace WorkingSpace_API.Controllers
{
    [Route("api/WorkingSpaceService/[controller]")]
    [ApiController]
    public class WorkingSpaceController : ControllerBase
    {
        private readonly IWorkingSpaceService _workingSpaceService;

        public WorkingSpaceController(IWorkingSpaceService workingSpaceService)
        {
            _workingSpaceService = workingSpaceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonMistakeCategory>>> GetCategories(
            [FromQuery] int offset = 0,     
            [FromQuery] int limit = 10,     
            [FromQuery] string direction = "asc",  
            [FromQuery] string sortBy = "ID"  
            )
        {
            try
            {
                var categories = await _workingSpaceService.GetAllCategoriesAsync(offset, limit, direction, sortBy);
                return new JsonResult(new APIReturn()
                {
                    code = 200,
                    message = "Success",
                    data = categories.Cast<object>().ToList()
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new CustomException(HttpStatusCode.NotFound, "An unexpected error occurred",
                        "GetCategories - WorkingSpace_API : Categories could not be retrieved from the repository",
                        null));
            }
            
        }
    }
}

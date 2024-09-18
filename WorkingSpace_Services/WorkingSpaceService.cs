using ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkingSpace_BusinessObject.Models;
using WorkingSpace_Repositories;

namespace WorkingSpace_Services
{
    public class WorkingSpaceService : IWorkingSpaceService
    {
        private readonly IWorkingSpaceRepository _workingSpaceRepository;

        public WorkingSpaceService(IWorkingSpaceRepository workingSpaceRepository)
        {
            _workingSpaceRepository = workingSpaceRepository;
        }

        public async Task<IEnumerable<CommonMistakeCategory>> GetAllCategoriesAsync(int offset, int limit, string direction, string sortBy)
        {

            try
            {
                var categories = await _workingSpaceRepository.GetAllAsync(offset, limit, direction, sortBy);
                if (categories == null)
                {
                    throw new CustomException(HttpStatusCode.NotFound, "An unexpected error occurred",
                        "GetAllCategoriesAsync - WorkingSpace_Service : Categories could not be retrieved from the repository",
                        null);
                }
                return categories;
            }
            catch (Exception ex) 
            {
                    throw new CustomException(HttpStatusCode.BadRequest, "An unexpected error occurred",
                        $"GetAllCategoriesAsync - WorkingSpace_Service : {ex.Message}",
                        null);
            }
        }
    }
}

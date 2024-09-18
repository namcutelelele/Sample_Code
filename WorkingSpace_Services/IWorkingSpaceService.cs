using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingSpace_BusinessObject.Models;

namespace WorkingSpace_Services
{
    public interface IWorkingSpaceService
    {
        Task<IEnumerable<CommonMistakeCategory>> GetAllCategoriesAsync(int offset, int limit, string direction, string sortBy);
    }
}

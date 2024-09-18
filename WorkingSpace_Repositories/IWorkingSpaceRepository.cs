using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingSpace_BusinessObject.Models;

namespace WorkingSpace_Repositories
{
    public interface IWorkingSpaceRepository
    {
        public Task<IEnumerable<CommonMistakeCategory>> GetAllAsync(int offset, int limit, string direction, string sortBy);
    }
}

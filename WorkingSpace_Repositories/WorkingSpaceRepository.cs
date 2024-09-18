using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingSpace_BusinessObject.Models;
using WorkingSpace_DataAccessLayer;
using WorkingSpace_DataAccessLayer.DataLayer;

namespace WorkingSpace_Repositories
{
    public class WorkingSpaceRepository : IWorkingSpaceRepository
    {
        private readonly WorkingSpaceDAO _workingSpaceDAO;

        public WorkingSpaceRepository(WorkingSpaceDAO workingSpaceDAO)
        {
            _workingSpaceDAO = workingSpaceDAO;
        }

        public Task<IEnumerable<CommonMistakeCategory>> GetAllAsync(int offset, int limit, string direction, string sortBy) => _workingSpaceDAO.GetAllAsync(offset, limit, direction, sortBy);
    }
}

using ExceptionHandling;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkingSpace_BusinessObject.Models;

namespace WorkingSpace_DataAccessLayer.DataLayer
{
    public class WorkingSpaceDAO
    {
        private readonly MyDbContext _myDbContext;

        public WorkingSpaceDAO(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task<WorkingSpace> InsertWorkingSpace(WorkingSpace workingSpace)
        {
            _myDbContext.WorkingSpaces.Add(workingSpace);
            await _myDbContext.SaveChangesAsync();
            return workingSpace;
        }

        public async Task<IEnumerable<CommonMistakeCategory>> GetAllAsync(int offset, int limit, string direction, string sortBy)
        {
            if (offset < 0) offset = 0;
            if (limit <= 0) limit = 10;
            if (direction != "asc" && direction != "desc") direction = "asc";

            var query = _myDbContext.CommonMistakeCategories.AsQueryable();

            switch (sortBy.ToLower())
            {
                case "name":
                    query = direction == "asc" ? query.OrderBy(e => e.Name) : query.OrderByDescending(e => e.Name);
                    break;
                case "id":
                    query = direction == "asc" ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);
                    break;
                default:
                    throw new CustomException(HttpStatusCode.BadRequest, "Invalid sortBy parameter.", "Invalid sortBy parameter.", null);
            }


            query = query.Skip(offset).Take(limit);

            return await query.ToListAsync();

            //return await _myDbContext.CommonMistakeCategories.ToListAsync();
        }

    }
}

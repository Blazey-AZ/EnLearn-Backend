using enlearn.Data;
using enlearn.Entities;
using enlearn.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Repository
{
    public class CourseRepository : ICourseRepository
    {

        private readonly DataContext _context;
        public CourseRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<List<course>> GetAllCoursesAsync()
        {
            return await _context.tblcap_course.ToListAsync();
        }




        public async Task<course> GetCourseIdByAsync(int CourseID)
        {
            return await _context.tblcap_course.FirstOrDefaultAsync(e => e.courseid == CourseID);
        }


        public async Task<bool> ContainsAsync(string name)
        {
            return await _context.tblcap_course.Where(c => c.courseshortname != null && c.courseshortname == name).CountAsync() >
                   0;
        }

        public async Task<int> RegisterAsync(course course)
        {
            await _context.tblcap_course.AddAsync(course);
            return await _context.SaveChangesAsync();
        }


        public async Task<course> GetCourseAsync(int CourseID)
        {
            return await _context.tblcap_course.FirstOrDefaultAsync(e => e.courseid == CourseID);
        }


        public async Task<int> UpdateAsync(course course)
        {
            _context.tblcap_course.Update(course);
            return await _context.SaveChangesAsync();
        }


        public async Task<course> DeleteAsync(int CourseID)
        {
            var result = await _context.tblcap_course.FirstOrDefaultAsync(e => e.courseid == CourseID);
            if (result != null)
            {
                _context.tblcap_course.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;

        }


    }
}
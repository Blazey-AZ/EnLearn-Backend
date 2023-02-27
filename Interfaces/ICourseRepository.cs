using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.DTOs;
using enlearn.Entities;
using Microsoft.EntityFrameworkCore;



namespace enlearn.Interfaces
{
    public interface ICourseRepository
    {
        Task<bool> ContainsAsync(string name);

        Task<int> RegisterAsync(course course);

        Task<course> GetCourseIdByAsync(int CourseID);

        Task<List<course>> GetAllCoursesAsync();
        Task<course> GetCourseAsync(int CourseID);

        Task<int> UpdateAsync(course course);
        Task<course> DeleteAsync(int CourseID);




    }
}
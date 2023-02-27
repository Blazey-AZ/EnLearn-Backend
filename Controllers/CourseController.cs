using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using enlearn.Data;
using enlearn.DTOs;
using enlearn.Entities;
using enlearn.Interfaces;
using enlearn.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enlearn.Controllers
{
    public class CourseController : BaseApiController
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;

        }
        // private readonly DataContext _context;
        // public CourseController(DataContext context)
        // {
        //     _context = context;
        // }




        [HttpGet("getcourse")]
        public async Task<IActionResult> GetCourses()
        {
            IReadOnlyList<course> readList = await _courseRepository.GetAllCoursesAsync();
            return Ok(readList);
        }

        // [HttpGet("getcourse")]
        // public async Task<ActionResult<CourseDtos>> GetCourses()
        // {
        //     List<CourseDtos> courseDtos = new List<CourseDtos>();

        //     List<course> courses = await _context.tblcap_course.ToListAsync();

        //     foreach (var item in courses)
        //     {
        //         courseDtos.Add(new CourseDtos()
        //         {
        //             CourseID = item.courseid,
        //             CourseName = item.coursename,
        //             CourseShortName = item.courseshortname,
        //             CourseType = item.coursetype,
        //             CourseDescription = item.coursedescription,
        //         });
        //     }

        //     return Ok(courseDtos);

        // }



        [HttpGet("getcourse/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            Console.WriteLine(id);
            var course = await _courseRepository.GetCourseIdByAsync(id);
            Console.WriteLine(course != null);
            if (course != null)
                return Ok(course);

            return NotFound($"Course with ID = {id} not found");
        }



        // [HttpGet("getcourse/{id}")]
        // public async Task<ActionResult<course>> GetCourse(int id)
        // {


        //     var course = await _context.tblcap_course.FirstOrDefaultAsync(c => c.courseid == id);

        //     if (course == null)
        //         return NoContent();

        //     return course;
        // }



        [HttpPost("coursereg")] //api/course/coursereg/
        public async Task<ActionResult<CourseDtos>> CourseReg(CourseDtos courseDto)

        {
            bool contains = await _courseRepository.ContainsAsync(courseDto.CourseShortName);
            if (contains)
                return NotFound($"A category with {courseDto.CourseShortName} already exists in the system!");
            var course = new course()
            {

                coursename = courseDto.CourseName,
                courseshortname = courseDto.CourseShortName,
                coursetype = courseDto.CourseType,
                coursedescription = courseDto.CourseDescription,


            };

            await _courseRepository.RegisterAsync(course);
            return Ok();

        }







        // [HttpPost("coursereg")] //api/course/coursereg/
        // public async Task<ActionResult<CourseDtos>> CourseReg(CourseDtos courseDto)

        // {
        //     if (await Course(courseDto.CourseShortName)) return BadRequest("Username is taken");
        //     var course = new course
        //     {

        //         coursename = courseDto.CourseName,
        //         courseshortname = courseDto.CourseShortName,
        //         coursetype = courseDto.CourseType,
        //         coursedescription = courseDto.CourseDescription,


        //     };

        //     _context.tblcap_course.Add(course);
        //     await _context.SaveChangesAsync();

        //     return courseDto;
        // }
        // private async Task<bool> Course(String CourseShortName)
        // {
        //     return await _context.tblcap_course.AnyAsync(x => x.courseshortname == CourseShortName.ToLower());
        // }





        [HttpPost("editcourse")]
        public async Task<ActionResult<CourseDtos>> CourseEdit(CourseDtos courseDto)
        {
            var course = new course()
            {
                courseid = courseDto.CourseID,
                coursename = courseDto.CourseName,
                courseshortname = courseDto.CourseShortName,
                coursetype = courseDto.CourseType,
                coursedescription = courseDto.CourseDescription,
            };
            await _courseRepository.UpdateAsync(course);
            return Ok();
        }

        

        // [HttpPost("editcourse")] //api/course/editcourse/
        // public async Task<ActionResult<CourseDtos>> CourseEdit(CourseDtos courseDto)

        // {
        //     var course = new course
        //     {
        //         courseid = courseDto.CourseID,
        //         coursename = courseDto.CourseName,
        //         courseshortname = courseDto.CourseShortName,
        //         coursetype = courseDto.CourseType,
        //         coursedescription = courseDto.CourseDescription,


        //     };

        //     _context.tblcap_course.Update(course);
        //     await _context.SaveChangesAsync();

        //     return courseDto;
        // }










        [HttpDelete("coursedelete/{id}")]
        public async Task<ActionResult<course>> DeleteAsync(int id)
        {
            try
            {
                var getById = await _courseRepository.GetCourseAsync(id);
                if (getById == null)
                {
                    return NotFound($"Course with ID = {id} not found");
                }
                return await _courseRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deletin data!");
            }
        }
    }
}

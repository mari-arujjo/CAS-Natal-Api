using System.Runtime.Intrinsics.X86;
using System;
using api.Courses.Dtos;
using api.Lessons;
using api.Enrollments;

namespace api.Courses
{
    // Nessa classe, iremos criar um método de extensão.
    // Permite adicionar um novo método a uma classe existente sem precisar modificar essa classe diretamente ou criar uma subclasse.
    public static class CourseMapper
    {
        public static CourseDto ConvertToCourseDto(this Course c)
        {
            return new CourseDto
            {
                id = c.Id,
                courseCode = c.CourseCode,
                name = c.Name,
                symbol = c.Symbol,
                description = c.Description,
                photo = c.Photo,
                lessons = c.Lessons.Select(l => l.ConvertToLessonDto()).ToList(),
                enrollments = c.Enrollments.Select(e => e.ConvertToEnrollmentDto()).ToList()
            };
        }

        public static Course CreateNewCourseDto(this CreateCourseDto c)
        {
            return new Course
            {
                Name = c.name,
                Symbol = c.symbol,
                Description = c.description
            };
        }
    }
}

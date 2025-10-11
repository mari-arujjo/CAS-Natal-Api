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
                Id = c.Id,
                CourseCode = c.CourseCode,
                Name = c.Name,
                Symbol = c.Symbol,
                Description = c.Description,
                Photo = c.Photo,
                Lessons = c.Lessons.Select(l => l.ConvertToLessonDto()).ToList(),
                Enrollments = c.Enrollments.Select(e => e.ConvertToEnrollmentDto()).ToList()
            };
        }

        public static Course CreateNewCourseDto(this CreateCourseDto c)
        {
            return new Course
            {
                Name = c.Name,
                Symbol = c.Symbol,
                Description = c.Description
            };
        }
    }
}

using System.Runtime.Intrinsics.X86;
using System;

namespace api.Courses.Dtos
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
                Name = c.Name,
                Abbreviation = c.Abbreviation,
                Description = c.Description,
                Photo = c.Photo
            };
        }

        public static Course CreateNewCourseDto(this CourseDto c)
        {
            return new Course
            {
                Id = c.Id,
                Name = c.Name,
                Abbreviation = c.Abbreviation,
                Description = c.Description,
                Photo = c.Photo
            };
        }

    }
}

using api.Glossaries;
using api.Lessons.Dtos;

namespace api.Lessons
{
    public static class LessonMapper
    {
        public static LessonDto ConvertToLessonDto(this Lesson l)
        {
            return new LessonDto
            {
                Id = l.Id,
                LessonCode = l.LessonCode,
                Name = l.Name,
                Completed = l.Completed,
                Url = l.Url,
                Content = l.Content,
                CourseId = l.CourseId,
                Glossaries = l.Glossaries.Select(g => g.ConvertToGlossaryDto()).ToList(),
            };
        }

        public static Lesson CreateNewLessonDto(this CreateLessonDto dto, Guid courseId)
        {
            return new Lesson 
            {
                Name = dto.Name,
                //Completed = dto.Completed,
                Url = dto.Url,
                Content = dto.Content,
                CourseId = courseId
            };
        }

    }
}

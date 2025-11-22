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
                id = l.Id,
                lessonCode = l.LessonCode,
                name = l.Name,
                completed = l.Completed,
                url = l.Url,
                content = l.Content,
                courseId = l.CourseId,
                signs = l.Signs.Select(g => g.ConvertToGlossaryDtoSimple()).ToList(),
            };
        }

        public static LessonDtoSimple ConvertToLessonDtoSimple(this Lesson l)
        {
            return new LessonDtoSimple
            {
                id = l.Id,
                lessonCode = l.LessonCode,
                name = l.Name
            };
        }

        public static Lesson CreateNewLessonDto(this CreateLessonDto dto, Guid courseId)
        {
            return new Lesson 
            {
                Name = dto.name,
                //Completed = dto.Completed,
                Url = dto.url,
                Content = dto.content,
                CourseId = courseId
            };
        }

    }
}

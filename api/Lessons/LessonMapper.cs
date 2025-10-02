using api.Lessons.Dtos;

namespace api.Lessons
{
    public static class LessonMapper
    {
        public static LessonDto ConvertToLessonDto(this Lesson lesson)
        {
            return new LessonDto
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Completed = lesson.Completed,
                Url = lesson.Url,
                Content = lesson.Content

            };
        }


    }
}

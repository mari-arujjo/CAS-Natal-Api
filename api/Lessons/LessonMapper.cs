using api.Glossaries;
using api.Lessons.Dtos;
using api.LessonTopics;
using api.LessonTopics.Dtos;

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
                order = l.Order,
                completed = l.Completed,
                url = l.Url,
                content = l.Content,
                courseId = l.CourseId,
                signs = l.Signs.Select(g => g.ConvertToSignDtoSimple()).ToList(),
                topics = l.LessonTopics.OrderBy(t => t.Order).Select(t => new LessonTopicDto
                {
                    id = t.Id,
                    order = t.Order,
                    title = t.Title,
                    textContent = t.TextContent
                }).ToList(),
            };
        }

        public static LessonDtoSimple ConvertToLessonDtoSimple(this Lesson l)
        {
            return new LessonDtoSimple
            {
                id = l.Id,
                lessonCode = l.LessonCode,
                name = l.Name,order = l.Order
            };
        }

        public static Lesson CreateNewLessonDto(this CreateLessonDto dto, Guid courseId)
        {
            return new Lesson 
            {
                Name = dto.name,
                //Completed = dto.Completed,
                Order = dto.order,
                Url = dto.url,
                Content = dto.content,
                CourseId = courseId,
                LessonTopics = dto.topics.Select(t => new LessonTopic
                {
                    Id = t.id,
                    Order = t.order,
                    Title = t.title,
                    TextContent = t.textContent
                }).ToList()
            };
        }

    }
}

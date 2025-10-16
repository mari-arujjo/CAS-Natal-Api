using api.Glossaries.Dtos;
using api.Lessons;

namespace api.Glossaries
{
    public static class GlossaryMapper
    {

        public static GlossaryDto ConvertToGlossaryDto(this Glossary g)
        {
            return new GlossaryDto
            {
                Id = g.Id,
                GlossaryCode = g.GlossaryCode,
                Sign = g.Sign,
                Description = g.Description,
                Url = g.Url,
                Photo = g.Photo,
                Category = g.Category,
                Lessons = g.Lessons.Select(l => l.ConvertToLessonDto()).ToList(),
            };
        }

        public static Glossary CreateNewGlossaryDto(this CreateGlossaryDto dto)
        {
            return new Glossary
            {
                Sign = dto.Sign,
                Description = dto.Description,
                Url = dto.Url,
                Category = dto.Category
            };
        }
    }
}

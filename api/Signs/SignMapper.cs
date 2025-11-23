using api.Lessons;
using api.Signs;
using api.Signs.Dtos;

namespace api.Glossaries
{
    public static class SignMapper
    {

        public static SignDto ConvertToSignDto(this Sign s)
        {
            return new SignDto
            {
                id = s.Id,
                signCode = s.SignCode,
                name = s.Name,
                description = s.Description,
                url = s.Url,
                photo = s.Photo,
                category = s.Category,
                lessons = s.Lessons.Select(l => l.ConvertToLessonDtoSimple()).ToList(),
            };
        }

        public static SignDtoSimple ConvertToSignDtoSimple(this Sign s)
        {
            return new SignDtoSimple
            {
                id = s.Id,
                signCode = s.SignCode,
                name = s.Name
            };
        }

        public static Sign CreateNewSignDto(this CreateSignDto dto)
        {
            return new Sign
            {
                Name = dto.name,
                Description = dto.description,
                Url = dto.url,
                Category = dto.category
            };
        }
    }
}

﻿
using api.Courses.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api.Courses.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> CourseExists(Guid id)
        {
            return _context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<Course> CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteAsync(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(l => l.Lessons).ToListAsync();
        }

        public async Task<Course?> GetBySymbol(string abbreviation)
        {
            return await _context.Courses.FirstOrDefaultAsync(a => a.Symbol == abbreviation);
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses.Include(l => l.Lessons).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> UpdateAsync(Guid id, UpdateCourseDto dto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;

            course.Name = dto.Name;
            course.Symbol = dto.Symbol;
            course.Description = dto.Description;
            //course.Photo = dto.Photo;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}

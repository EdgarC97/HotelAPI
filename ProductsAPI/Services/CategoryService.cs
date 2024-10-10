using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<CategoryDTO> categories, string message)> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();

            if (categories == null || categories.Count == 0)
            {
                return (null, "No categories found. Please check back later!");
            }

            return (categories, "Categories retrieved successfully!");
        }

        public async Task<(CategoryDTO category, string message)> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return (null, $"Category with ID {id} not found. Please check the ID and try again.");
            }

            return (category, "Category retrieved successfully!");
        }

        // Asynchronously creates a new category based on the provided CreateCategoryDTO.
        public async Task<(bool IsSuccess, CategoryDTO Category, string Message)> CreateCategoryAsync(CreateCategoryDTO createCategoryDto)
        {

            // Create a new Category entity from the provided DTO.
            var category = new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
            };

            // Add the new category to the context and save changes to the database.
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Map the new Category entity to CategoryDTO for the response.
            var categoryDto = new CategoryDTO
            {
                Id = category.Id,
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
            };

            return (true, categoryDto, "Category created successfully."); // Return success result.
        }

        // Asynchronously deletes a category by its ID.
        public async Task<(bool IsSuccess, string Message)> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id); // Find the category by ID.
            if (category == null)
            {
                return (false, "Category not found."); // Return failure if category is not found.
            }

            // Remove the category from the context and save changes to the database.
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return (true, "Category deleted successfully."); // Return success result.
        }

        public async Task<(bool IsSuccess, CategoryDTO Category, string Message)> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategoryDto)
        {
            var category = await _context.Categories.FindAsync(id); // Find the category by ID.
            if (category == null)
            {
                return (false, null, "Category not found."); // Return failure if the category is not found.
            }

            // Update the category properties with the new values from the DTO.
            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;

            // Save changes to the database.
            await _context.SaveChangesAsync();

            // Map the updated Category entity to CategoryDTO for the response.
            var categoryDto = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return (true, categoryDto, "Category updated successfully."); // Return success result.
        }
    }
}
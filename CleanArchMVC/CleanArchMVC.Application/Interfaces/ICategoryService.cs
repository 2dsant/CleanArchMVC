using CleanArchMVC.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Remove(int id);
    }
}

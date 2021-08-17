using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Domain;

namespace Application.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<string>> GetCategories(ConsultantDisplayDto user);
    }
}
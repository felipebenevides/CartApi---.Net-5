using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> ListMenu();
    }
}

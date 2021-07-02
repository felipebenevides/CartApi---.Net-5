using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface ICategoryService: IService<Category>
    {
        Task<List<Category>> ListMenu();

    }
}

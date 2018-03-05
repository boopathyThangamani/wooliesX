using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Repositories
{
    public interface IShopperHistoryRepository
    {
        Task<List<ShopperHistory>> GetShopperHistoryAsync();
    }
}

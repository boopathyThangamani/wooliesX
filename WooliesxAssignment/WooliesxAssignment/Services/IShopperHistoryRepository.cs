using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Services
{
    public interface IShopperHistoryRepository
    {
        Task<List<ShopperHistory>> GetShopperHistory();
    }
}

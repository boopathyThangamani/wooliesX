using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
    }
}
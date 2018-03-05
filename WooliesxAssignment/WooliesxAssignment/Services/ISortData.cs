using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesxAssignment.Enum;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Services
{
    public interface ISortData
    {
        Task<List<Product>> SortDataAsync(Sort sortOption);
    }
}

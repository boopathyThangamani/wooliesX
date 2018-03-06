using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Services
{
    public interface ITrolleyCalculator
    {
        Task<double> CalculateTrolleyTotal(TrolleyItems items);
    }
}

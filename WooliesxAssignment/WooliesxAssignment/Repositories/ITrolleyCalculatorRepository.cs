using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesxAssignment.Models;

namespace WooliesxAssignment.Repositories
{
    public interface ITrolleyCalculatorRepository
    {
        Task<double> TrolleyCalculator(TrolleyItems items);
    }
}

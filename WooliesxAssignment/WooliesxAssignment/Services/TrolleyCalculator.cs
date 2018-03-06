using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Serilog;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Models;
using WooliesxAssignment.Repositories;

namespace WooliesxAssignment.Services
{
    public class TrolleyCalculator : ITrolleyCalculator
    {
        private readonly ILogger _logger;
        private ITrolleyCalculatorRepository _trolleyCalculatorRepository;
        public TrolleyCalculator(ITrolleyCalculatorRepository trolleyCalculatorRepository, ILogger logger)
        {
            _logger = logger;
            _trolleyCalculatorRepository = trolleyCalculatorRepository;
        }

        public Task<double> CalculateTrolleyTotal(TrolleyItems items)
        {
            return _trolleyCalculatorRepository.TrolleyCalculator(items);
        }
    }
}
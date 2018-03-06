using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Serilog;
using WooliesxAssignment.Enum;
using WooliesxAssignment.Models;
using WooliesxAssignment.Services;

namespace WooliesxAssignment.Controllers
{
    [RoutePrefix("api/answers")]
    public class TrolleyCalculatorController : BaseController
    {
        private readonly ILogger _logger;
        private readonly ITrolleyCalculator _trolleyCalculator;

        public TrolleyCalculatorController(ITrolleyCalculator trolleyCalculator, ILogger logger)
        {
            _logger = logger;
            _trolleyCalculator = trolleyCalculator;
        }

        [HttpPost]
        [Route("trolleyTotal")]
        public async Task<IHttpActionResult> PostToTrolleyCalculator(TrolleyItems items)
        {
            //if (items == null)
            //{
            //    items.products = new List<TrollyProduct>()
            //    {
            //        new TrollyProduct()
            //        {
            //            name = "A",
            //            price = 2
            //        }
            //    };
            //    items.quantities = new List<ProductQuantity>()
            //    {
            //        new ProductQuantity()
            //        {
            //            name = "A",
            //            quantity = 2
            //        }
            //    };
            //    items.specials = new List<Special>()
            //    {
            //        new Special()
            //        {
            //            total =0,
            //           quantities = new List<ProductQuantity>()
            //            {
            //                new ProductQuantity()
            //                {
            //                    name = "A",
            //                    quantity = 2
            //                }
            //            }
            //        }
            //    };
            //}

            return Ok(await _trolleyCalculator.CalculateTrolleyTotal(items));
        }
    }
}

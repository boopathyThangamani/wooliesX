using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using WooliesxAssignment.Enum;
using WooliesxAssignment.Models;
using WooliesxAssignment.Repositories;

namespace WooliesxAssignment.Services
{
    public class SortData : ISortData
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _productRepository;
        private readonly IShopperHistoryRepository _shopperHistoryRepository;

        public SortData(IShopperHistoryRepository shopperHistoryRepository, IProductRepository productRepository,
            ILogger logger)
        {
            _logger = logger;
            _shopperHistoryRepository = shopperHistoryRepository;
            _productRepository = productRepository;
        }

        public async Task<List<Product>> SortDataAsync(Sort sortOption)
        {
            var products = await _productRepository.GetProductsAsync();
            switch (sortOption)
            {
                case Sort.Ascending:
                    return products.OrderBy(x => x.Name).ToList();
                case Sort.Descending:
                    return products.OrderByDescending(x => x.Name).ToList();
                case Sort.High:
                    return products.OrderByDescending(x => x.Price).ToList();
                case Sort.Low:
                    return products.OrderBy(x => x.Price).ToList();
                case Sort.Recommended:
                default:
                    var shopperHistory = await _shopperHistoryRepository.GetShopperHistoryAsync();
                    var result = shopperHistory.SelectMany(p => p.Products).GroupBy(p => p.Name).Select(c =>
                        new Product
                        {
                            Name = c.Key,
                            Quantity = c.Sum(qty => qty.Quantity),
                            Price = c.Max(prc => prc.Price)
                        }).ToList();

                    var notFound = new List<Product>();
                    foreach (var prod in products)
                    {
                        var found = false;
                        foreach (var r in result)
                            if (r.Name == prod.Name)
                            {
                                found = true;
                                break;
                            }

                        if (!found) notFound.Add(prod);
                    }

                    result.AddRange(notFound);

                    return result.OrderByDescending(x => x.Quantity).ToList();
            }
        }
    }
}
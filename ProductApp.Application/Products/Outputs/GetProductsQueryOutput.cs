using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Domain.Aggregates.Product.ValueObject;

namespace ProductApp.Application.Products.Outputs
{
    public class GetProductsQueryOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Stock Stock{ get; set; }
    }
}

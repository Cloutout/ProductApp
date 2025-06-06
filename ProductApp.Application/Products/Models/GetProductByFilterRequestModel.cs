using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Products.Models
{
    public class GetProductByFilterRequestModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

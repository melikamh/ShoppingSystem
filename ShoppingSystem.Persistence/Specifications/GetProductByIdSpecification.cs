using ShoppingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Specifications
{
    internal class GetProductByIdSpecification : Specification<Product>
    {
        public GetProductByIdSpecification(int id)
         : base(p => p.Id == id)
        {
        }
    }
}

using Microsoft.AspNetCore.Identity;
using ShoppingSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime MemberSince { get; set; }
        //public IEnumerable<Order> Orders { get; set; }
    }
}

using Graduation.Project.Entity.Base;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class Product : EntityBase
    {
        public Product()
        {
            Offers = new HashSet<Offer>();
            Policies = new HashSet<Policy>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}

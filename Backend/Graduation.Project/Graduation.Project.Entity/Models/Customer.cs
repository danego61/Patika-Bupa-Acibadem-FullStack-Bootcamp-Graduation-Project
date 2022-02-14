using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;

namespace Graduation.Project.Entity.Models
{
    public class Customer : EntityBase
    {
        public Customer()
        {
            OfferDetails = new HashSet<OfferDetail>();
            Offers = new HashSet<Offer>();
            Policies = new HashSet<Policy>();
            PolicyDetails = new HashSet<PolicyDetail>();
        }

        public string CustomerId { get; set; } = null!;
        public string? TcNo { get; set; }
        public string? Passaport { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public Genders Gender { get; set; }
        public string Gsm { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime Birthdate { get; set; }

        public virtual ICollection<OfferDetail> OfferDetails { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
        public virtual ICollection<PolicyDetail> PolicyDetails { get; set; }
    }
}

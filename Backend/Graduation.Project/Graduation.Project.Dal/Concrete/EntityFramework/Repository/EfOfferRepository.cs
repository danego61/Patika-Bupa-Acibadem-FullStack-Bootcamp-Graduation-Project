using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.Models;
using Graduation.Project.Entity.Static;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Concrete.EntityFramework.Repository
{
    public class EfOfferRepository : EfGenericRepository<Offer>, IOfferRepository
    {

        private readonly IProcedureFunctions procedure;

        public EfOfferRepository(DbContext context, IProcedureFunctions procedure) : base(context)
        {
            this.procedure = procedure;
        }

        public Offer AddOffer(DtoAddOffer offer)
        {
            return new Offer
            {
                OfferNumber = procedure.SpAddOffer(offer),
                CustomerId = offer.CustomerId,
                OfferStatus = offer.OfferStatus
            };
        }

        public void AddOfferDetail(decimal offerNumber, DtoAddOfferDetails offer)
        {
            procedure.SpAddOfferDetails(offerNumber, offer);
        }

        public void UpdateOfferStatus(decimal offerId, OfferStatus newStatus)
        {
            Find(offerId)!.OfferStatus = newStatus;
            context.SaveChanges();
        }

        public List<Offer> GetOffers(DtoOfferQuery query)
        {
            return procedure.SpGetOfferQuery(query);
        }

        public DtoUpdateProductResult UpdateOfferProduct(DtoOfferUpdateProduct product)
        {
            return procedure.SpOfferUpdateProduct(product);
        }

        public void UpdateOfferInstallment(decimal offerId, InstallmentTypes Installment)
        {
            procedure.SpBillUpdateInstallment(offerId, Installment);
        }

        public void OfferPayBill(DtoAddBillPayment billPayment)
        {
            procedure.SpAddBillPayment(billPayment);
        }
    }
}

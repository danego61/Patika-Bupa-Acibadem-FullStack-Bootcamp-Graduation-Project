using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Abstract
{
    public interface IOfferRepository : IGenericRepository<Offer>
    {

        List<Offer> GetOffers(DtoOfferQuery query);

        Offer AddOffer(DtoAddOffer offer);

        void AddOfferDetail(decimal offerNumber, DtoAddOfferDetails offer);

        void UpdateOfferStatus(decimal offerId, OfferStatus newStatus);

        DtoUpdateProductResult UpdateOfferProduct(DtoOfferUpdateProduct product);

        void UpdateOfferInstallment(decimal offerId, InstallmentTypes Installment);

        void OfferPayBill(DtoAddBillPayment billPayment);

    }
}

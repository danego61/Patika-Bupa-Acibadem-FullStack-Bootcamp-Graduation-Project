using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Interface
{
    public interface IOfferService : IGenericService<Offer>
    {

        IResponse<List<TDto>> GetOffers<TDto>(DtoOfferQuery query) where TDto : class, IDtoBase;

        IResponse<TDto> AddOffer<TDto>(DtoAddOffer offer) where TDto : class, IDtoBase;

        IResponse AddOfferDetail(decimal offerNumber, DtoAddOfferDetails offerDetail);

        IResponse CompleteOfferDetails(decimal offerId);

        IResponse<DtoUpdateProductResult> UpdateOfferProduct(decimal offerId, DtoUpdateOfferProduct product);

        IResponse UpdateOfferInstallment(decimal offerNumber, DtoUpdateOfferInstallment updateOfferInstallment);

        IResponse OfferPayBill(DtoAddBillPayment billPayment);

    }
}

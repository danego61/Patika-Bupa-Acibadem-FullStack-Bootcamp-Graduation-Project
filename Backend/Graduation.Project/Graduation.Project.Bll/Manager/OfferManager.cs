using AutoMapper;
using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Base;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Entity.Models;
using Graduation.Project.Entity.Static;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Bll.Manager
{
    public class OfferManager : GenericManager<Offer>, IOfferService
    {

        private readonly IOfferRepository repository;

        public OfferManager(IOfferRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
        }

        public IResponse<TDto> AddOffer<TDto>(DtoAddOffer offer) where TDto : class, IDtoBase
        {
            offer.OfferStatus = OfferStatus.InsuredsAdding;
            return new Response<TDto>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status201Created,
                Data = mapper.Map<TDto>(repository.AddOffer(offer))
            };
        }

        public IResponse<List<TDto>> GetOffers<TDto>(DtoOfferQuery query) where TDto : class, IDtoBase
        {
            return new Response<List<TDto>>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = mapper.Map<List<TDto>>(repository.GetOffers(query))
            };
        }

        public IResponse AddOfferDetail(decimal offerNumber, DtoAddOfferDetails offerDetail)
        {
            repository.AddOfferDetail(offerNumber, offerDetail);
            return new Response
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public IResponse CompleteOfferDetails(decimal offerId)
        {
            repository.UpdateOfferStatus(offerId, OfferStatus.ProductSelection);
            return new Response
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public IResponse<DtoUpdateProductResult> UpdateOfferProduct(decimal offerId, DtoUpdateOfferProduct product)
        {

            return new Response<DtoUpdateProductResult>
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = repository.UpdateOfferProduct(new DtoOfferUpdateProduct
                {
                    OfferNumber = offerId,
                    OfferStatus = OfferStatus.InstallmentSelection,
                    SelectedProduct = product.ProductId
                })
            };
        }

        public IResponse UpdateOfferInstallment(decimal offerNumber, DtoUpdateOfferInstallment updateOfferInstallment)
        {
            repository.UpdateOfferInstallment(offerNumber, updateOfferInstallment.Installment);
            repository.UpdateOfferStatus(offerNumber, OfferStatus.PaymentPending);
            return new Response
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK
            };
        }

        public IResponse OfferPayBill(DtoAddBillPayment billPayment)
        {
            repository.OfferPayBill(billPayment);
            repository.UpdateOfferStatus(billPayment.OfferId, OfferStatus.Completed);
            return new Response
            {
                Message = "Success",
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}

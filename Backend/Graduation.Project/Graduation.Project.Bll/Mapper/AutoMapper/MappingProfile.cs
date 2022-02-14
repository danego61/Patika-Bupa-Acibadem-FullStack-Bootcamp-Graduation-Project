using AutoMapper;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, DtoProduct>();
            CreateMap<Customer, DtoCustomer>();
            CreateMap<Offer, DtoOffer>()
                .ForMember(x => x.SelectedProduct, x => x.MapFrom(x => x.SelectedProductNavigation));
            CreateMap<Bill, DtoBill>();
            CreateMap<OfferDetail, DtoOfferDetail>();
            CreateMap<BillPayment, DtoBillPayment>();
        }

    }
}

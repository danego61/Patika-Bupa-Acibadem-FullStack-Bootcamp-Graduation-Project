using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.Models;
using Graduation.Project.Entity.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Abstract
{
    public interface IProcedureFunctions
    {

        decimal SpAddProduct(DtoAddProduct newProduct);

        decimal SpAddPolicy(DtoAddPolicy newPolicy);

        void SpAddOfferDetails(decimal offerNumber, DtoAddOfferDetails offerDetails);

        decimal SpAddOffer(DtoAddOffer addOffer);

        string SpAddCustomer(DtoAddCustomer addCustomer);

        void SpAddBillPayment(DtoAddBillPayment billPayment);

        DtoUpdateProductResult SpOfferUpdateProduct(DtoOfferUpdateProduct offerUpdateProduct);

        List<Offer> SpGetOfferQuery(DtoOfferQuery query);

        List<Policy> SpGetPolicyQuery(DtoPolicyQuery query);

        void SpBillUpdateInstallment(decimal offerId, InstallmentTypes installment);

    }
}

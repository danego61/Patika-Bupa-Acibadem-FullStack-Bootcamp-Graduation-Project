using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.Models;
using Graduation.Project.Entity.Static;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Concrete.EntityFramework
{
    public class EfProcedureFunctions : IProcedureFunctions
    {

        private readonly DbContext context;

        public EfProcedureFunctions(DbContext context)
        {
            this.context = context;
        }

        public List<Offer> SpGetOfferQuery(DtoOfferQuery query)
        {
            return context.Set<Offer>().FromSqlRaw("BEGIN SP_OFFER_QUERY(:ITC, :INAME, :ISURNAME, :IDTC, :IDNAME, :IDSURNAME, :ONUMBER, : OSTATUS, :RES); END;",
            new OracleParameter[]
            {
                new("ITC", query.ByInsurerTC),
                new("INAME", query.ByInsurerName),
                new("ISURNAME", query.ByInsurerSurname),
                new("IDTC", query.ByInsuredTC),
                new("IDNAME", query.ByInsuredName),
                new("IDSURNAME", query.ByInsuredSurname),
                new("ONUMBER", query.ByOfferNumber),
                new("OSTATUS", query.ByOfferStatus),
                new("RES", OracleDbType.RefCursor, ParameterDirection.Output)
            }).ToList();
        }

        public List<Policy> SpGetPolicyQuery(DtoPolicyQuery query)
        {
            return context.Set<Policy>().FromSqlRaw("BEGIN SP_OFFER_QUERY(:ITC, :INAME, :ISURNAME, :IDTC, :IDNAME, :IDSURNAME, :PNUMBER, : PSTATUS, :RES); END;",
            new OracleParameter[]
            {
                new("ITC", query.ByInsurerTC),
                new("INAME", query.ByInsurerName),
                new("ISURNAME", query.ByInsurerSurname),
                new("IDTC", query.ByInsuredTC),
                new("IDNAME", query.ByInsuredName),
                new("IDSURNAME", query.ByInsuredSurname),
                new("PNUMBER", query.ByPolicyNumber),
                new("PSTATUS", query.ByPolicyStatus),
                new("RES", OracleDbType.RefCursor, ParameterDirection.Output)
            }).ToList();
        }

        public void SpAddBillPayment(DtoAddBillPayment billPayment)
        {
            context.Database.ExecuteSqlRaw("BEGIN SP_ADD_BILL_PAYMENT(:oid, :cno, :cname, :cmounth, :cyear, :ctype); END;", new OracleParameter[]
            {
                new("oid", billPayment.OfferId),
                new("cno", billPayment.CardNo),
                new("cname", billPayment.CardName),
                new("cmounth", billPayment.CardDateMounth),
                new("cyear", billPayment.CardDateYear),
                new("ctype", billPayment.CardType)
            });
        }

        public string SpAddCustomer(DtoAddCustomer addCustomer)
        {
            OracleParameter id = new("ID", OracleDbType.Char, 9);
            id.Direction = ParameterDirection.Output;
            context.Database.ExecuteSqlRaw("BEGIN SP_ADD_CUSTOMER(:TC, :PASSAPORT, :NAME, :SURNAME, :GENDER, :GSM, :MAIL, :ADDRESS, :BIRTHDATE, :ID); END;",
            new[]
            {
                new("TC", addCustomer.TcNo),
                new("PASSAPORT", addCustomer.Passaport),
                new("NAME", addCustomer.Name),
                new("SURNAME", addCustomer.Surname),
                new("GENDER", (int)addCustomer.Gender),
                new("GSM", addCustomer.Gsm),
                new("MAIL", addCustomer.Mail),
                new("ADDRESS", addCustomer.Address),
                new("BIRTHDATE", addCustomer.Birthdate),
                id
            });
            return id.Value.ToString()!;
        }

        public decimal SpAddOffer(DtoAddOffer addOffer)
        {
            OracleParameter id = new("id", OracleDbType.Decimal, ParameterDirection.Output);
            context.Database.ExecuteSqlRaw("BEGIN SP_ADD_OFFER(:status, :cid, :id); END;", new[]
            {
                new("status", (int)addOffer.OfferStatus),
                new("cid", addOffer.CustomerId),
                id
            });
            return Convert.ToDecimal(id.Value.ToString());
        }

        public void SpAddOfferDetails(decimal offerNumber, DtoAddOfferDetails offerDetails)
        {
            context.Database.ExecuteSqlRaw("BEGIN SP_ADD_OFFER_DETAILS(:oid, :cid, :h, :w, :r, :j); END;", new OracleParameter[]
            {
                new("oid", offerNumber),
                new("cid", offerDetails.CustomerId),
                new("h", offerDetails.Height),
                new("w", offerDetails.Weight),
                new("r", (int)offerDetails.Relationship),
                new("j", offerDetails.Job)
            });
        }

        public decimal SpAddPolicy(DtoAddPolicy newPolicy)
        {
            OracleParameter id = new("id", OracleDbType.Decimal, ParameterDirection.Output);
            context.Database.ExecuteSqlRaw("BEGIN SP_ADD_POLICY(:oid, :pstatus, :id); END;", new[]
            {
                new("oid", newPolicy.OfferId),
                new("pstatus", (int)newPolicy.PolicyStatus),
                id
            });
            return Convert.ToDecimal(id.Value.ToString());
        }

        public decimal SpAddProduct(DtoAddProduct newProduct)
        {
            OracleParameter id = new("id", OracleDbType.Decimal, ParameterDirection.Output);
            context.Database.ExecuteSqlRaw("BEGIN SP_ADD_PRODUCT(:name, :price, :id); END;", new[]
            {
                new("name", newProduct.ProductName),
                new("price", newProduct.Price),
                id
            });
            return Convert.ToDecimal(id.Value.ToString());
        }

        public DtoUpdateProductResult SpOfferUpdateProduct(DtoOfferUpdateProduct offerUpdateProduct)
        {
            OracleParameter billId = new("bid", OracleDbType.Decimal, ParameterDirection.Output);
            OracleParameter price = new("p", OracleDbType.Decimal, ParameterDirection.Output);
            context.Database.ExecuteSqlRaw("BEGIN SP_OFFER_UPDATE_PRODUCT(:oid, :spid, :os, :bid, :p); END;", new[]
            {
                new("oid", offerUpdateProduct.OfferNumber),
                new("spid", offerUpdateProduct.SelectedProduct),
                new("os", (int)offerUpdateProduct.OfferStatus),
                billId,
                price
            });
            return new DtoUpdateProductResult
            {
                BillId = Convert.ToDecimal(billId.Value.ToString()),
                Price = Convert.ToDecimal(price.Value.ToString())
            };
        }

        public void SpBillUpdateInstallment(decimal offerId, InstallmentTypes installment)
        {
            context.Database.ExecuteSqlRaw("BEGIN SP_BILL_UPDATE_INSTALLMENT(:oid, :i); END;", new OracleParameter[]
            {
                new("oid", offerId),
                new("i", (int)installment)
            });
        }
    }
}

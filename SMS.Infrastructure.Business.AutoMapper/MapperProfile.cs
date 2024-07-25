using AutoMapper;
using SMS.Domain.Entities;
using SMS.Infrastructure.Model;

namespace SMS.Infrastructure.Business.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<CustomerPayment, CustomerPaymentModel>().ReverseMap();
            CreateMap<Invoice, InvoiceModel>().ReverseMap();
            CreateMap<InvoiceLine, InvoiceLineModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Purchaseorder, PurchaseorderModel>().ReverseMap();
            CreateMap<PurchasingExpenses, PurchasingExpensesModel>().ReverseMap();
            CreateMap<Vendor, VendorModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseModel>().ReverseMap();
        }
    }
}

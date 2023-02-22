using AutoMapper;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNestAPI.Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderReq, SnOrder>();
            CreateMap<SnOrder, OrderRes>();
            CreateMap<UserReq, SnUser>();
            CreateMap<SnUser, UserRes>();
            CreateMap<ProductReq, SnProduct>();
            CreateMap<SnProduct, ProductRes>();
            CreateMap<SupplierReq, SnSupplier>();
            CreateMap<SnSupplier, SupplierRes>();
            CreateMap<SupplierProductReq, SnSupplierProduct>();
            CreateMap<SnSupplierProduct, SupplierProductRes>();
            CreateMap<ContainerReq, SnContainer>();
            CreateMap<SnContainer, ContainerRes>();
            CreateMap<SnUserContainer, UserContainerDetailRes>();
            CreateMap<UserAddressReq, SnUserAddress>();
            CreateMap<SnUserAddress, UserAddressRes>();
            CreateMap<UserContainerReq, SnUserContainer>();
            CreateMap<SnUserContainer, UserContainerRes>();
            CreateMap<CategoryReq, SnCategory>();
            CreateMap<SnCategory, CategoryRes>();
            CreateMap<ContainerLogReq, SnContainerLog>();
            CreateMap<SnContainerLog, ContainerLogRes>();
            CreateMap<ContainerRuleReq, SnContainerRule>();
            CreateMap<SnContainerRule, ContainerRuleRes>();
            CreateMap<ShoppingListReq, SnShoppingList>();
            CreateMap<SnShoppingList, ShoppingListRes>();
            CreateMap<UserPaymentMethodReq, SnUserPaymentMethod>();
            CreateMap<SnUserPaymentMethod, UserPaymentMethodRes>();
            CreateMap<CategoryReq, SnCategory>();
            CreateMap<SnCategory, CategoryRes>();
        }
    }
}

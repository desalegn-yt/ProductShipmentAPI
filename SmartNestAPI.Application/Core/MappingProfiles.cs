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
            CreateMap<SupplierReq, SnSupplier>();
            CreateMap<SnSupplier, SupplierRes>();
            CreateMap<ContainerReq, SnContainer>();
            CreateMap<SnContainer, ContainerRes>();
            CreateMap<UserAddressReq, SnUserAddress>();
            CreateMap<SnUserAddress, UserAddressRes>();

        }
    }
}

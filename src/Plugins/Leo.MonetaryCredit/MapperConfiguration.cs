using AutoMapper;
using Grand.Infrastructure.Mapper;
using Leo.MonetaryCredit.Domain;
using Leo.MonetaryCredit.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit
{
    public class MapperConfiguration : Profile, IAutoMapperProfile
    {
        public int Order => 0;

        public MapperConfiguration()
        {

            CreateMap<CustomerBalanceData, MonetaryCreditUserInfoModel>();
            CreateMap<MonetaryCreditUserInfoModel, CustomerBalanceData>();

        }

    }
}

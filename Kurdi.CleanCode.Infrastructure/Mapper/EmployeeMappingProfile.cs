using AutoMapper;
using Kurdi.CleanCode.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Kurdi.CleanCode.Infrastructure.DTOs;
using System.Linq;

namespace Kurdi.CleanCode.Infrastructure.Mapper
{
    class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<IQueryable<Employee>, IQueryable<EmployeeDTO>>().ReverseMap();
        }
    }
}

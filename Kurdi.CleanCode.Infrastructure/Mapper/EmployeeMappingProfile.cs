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
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<IQueryable<Employee>, IQueryable<EmployeeDto>>().ReverseMap();
        }
    }
}

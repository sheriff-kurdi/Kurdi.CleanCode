using AutoMapper;
using CleanCode.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CleanCode.Infrastructure;

namespace CleanCode.Infrastructure.Mapper
{
    class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, DTOs.Employee>();
        }
    }
}

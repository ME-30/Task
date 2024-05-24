using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BL.Model;
using Task.DAL.Entity;

namespace Task.BL.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}

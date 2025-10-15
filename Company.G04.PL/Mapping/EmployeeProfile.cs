using AutoMapper;
using Company.G04.DAL.Models;
using Company.G04.PL.Dtos;

namespace Company.G04.PL.Mapping
{
    //CLR
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
                
            CreateMap<Employee, CreateEmployeeDto>();

        }

    }
}

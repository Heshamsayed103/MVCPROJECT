using Company.G04.BLL.Interfaces;
using Company.G04.DAL.Data.Configuration;
using Company.G04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(CompanyDbContext context):base(context) 
        {
            
        }

    }
}

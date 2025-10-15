using Company.G04.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
     Task <List<Employee>> GetByNameAsync(string name);
    }
}

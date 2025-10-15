using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAL.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public IDepartmentRepository DepartmentRepository { get; }//NULL
       
        public IEmployeeRepository EmployeeRepository { get; }//NULL
        
        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            DepartmentRepository = new DepartmentRepository(_context);
            EmployeeRepository = new EmployeeRepository(_context);
        
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync(); 
        }

        public async ValueTask DisposeAsync()
        {
           await  _context.DisposeAsync();
        }
    }
}

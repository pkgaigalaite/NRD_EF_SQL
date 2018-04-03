using akademija.EF.repositories;
using Microsoft.EntityFrameworkCore;
using NrdAkademija.Ef.entities;
using System.Collections.Generic;
using System.Linq;

namespace NrdAkademija.Ef.repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NrdAkademija2018Context context) : base(context)
        {
        }

        public List<Employee> GetEmployees()
        {
            return NrdAkademija2018Context.Employee
                .Include(c => c.EmployeeInventory)
                .ThenInclude(c => c.Inventory)
                .ToList();
        }



        public NrdAkademija2018Context NrdAkademija2018Context
        {
            get { return Context as NrdAkademija2018Context; }
        }
    }
}


